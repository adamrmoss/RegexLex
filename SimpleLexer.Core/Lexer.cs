using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleLexer.Core
{
  public class Lexer<TToken>
  {
    private Regex endOfLineRegex = new Regex(@"\r\n|\r|\n", RegexOptions.Compiled);
    private IList<TokenDefinition<TToken>> tokenDefinitions = new List<TokenDefinition<TToken>>();

    public void AddDefinition(TokenDefinition<TToken> tokenDefinition)
    {
      tokenDefinitions.Add(tokenDefinition);
    }

    public IEnumerable<Token<TToken>> Tokenize(string source)
    {
      int currentIndex = 0;
      int currentLine = 1;
      int currentColumn = 0;

      while (currentIndex < source.Length) {
        TokenDefinition<TToken> matchedDefinition = null;
        int matchLength = 0;

        foreach (var rule in tokenDefinitions) {
          var match = rule.Regex.Match(source, currentIndex);

          if (match.Success && (match.Index - currentIndex) == 0) {
            matchedDefinition = rule;
            matchLength = match.Length;
            break;
          }
        }

        if (matchedDefinition == null) {
          throw new Exception(string.Format("Unrecognized symbol '{0}' at index {1} (line {2}, column {3}).", source[currentIndex], currentIndex, currentLine, currentColumn));
        } else {
          var value = source.Substring(currentIndex, matchLength);

          if (!matchedDefinition.IsIgnored) {
            yield return new Token<TToken> {
              Type = matchedDefinition.Type,
              Value = value,
              Position = new TokenPosition { Index = currentIndex, Line = currentLine, Column = currentColumn }
           };
          }

          var endOfLineMatch = endOfLineRegex.Match(value);
          if (endOfLineMatch.Success) {
            currentLine += 1;
            currentColumn = value.Length - (endOfLineMatch.Index + endOfLineMatch.Length);
          } else {
            currentColumn += matchLength;
          }

          currentIndex += matchLength;
        }
      }

      yield return new Token<TToken> {
        Type = default(TToken),
        Value = null,
        Position = new TokenPosition { Index = currentIndex, Line = currentLine, Column = currentColumn }
      };
    }
  }
}
