using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexLex
{
    public class Lexer
    {
        private readonly Regex endOfLineRegex = new Regex(@"\r\n|\r|\n", RegexOptions.Compiled);
        private readonly IList<TokenDefinition> tokenDefinitions = new List<TokenDefinition>();

        public void AddDefinition(TokenDefinition tokenDefinition)
        {
            this.tokenDefinitions.Add(tokenDefinition);
        }

        public IEnumerable<Token> Tokenize(string source)
        {
            var currentIndex = 0;
            var currentLine = 1;
            var currentColumn = 0;

            while (currentIndex < source.Length)
            {
                var matchedDefinition = this.matchTokenDefinition(source, currentIndex, out var matchLength);

                if (matchedDefinition == null)
                {
                    throw new Exception($"Unrecognized symbol '{source[currentIndex]}' at index {currentIndex} (line {currentLine}, column {currentColumn}).");
                } else
                {
                    var value = source.Substring(currentIndex, matchLength);

                    if (!matchedDefinition.IsIgnored)
                    {
                        yield return new Token
                        {
                            Type = matchedDefinition.Type,
                            Value = value,
                            Position = new TokenPosition { Index = currentIndex, Line = currentLine, Column = currentColumn }
                        };
                    }

                    var endOfLineMatch = this.endOfLineRegex.Match(value);
                    if (endOfLineMatch.Success)
                    {
                        currentLine += 1;
                        currentColumn = value.Length - (endOfLineMatch.Index + endOfLineMatch.Length);
                    } else
                    {
                        currentColumn += matchLength;
                    }

                    currentIndex += matchLength;
                }
            }

            yield return new Token
            {
                Type = null,
                Value = null,
                Position = new TokenPosition { Index = currentIndex, Line = currentLine, Column = currentColumn }
            };
        }

        private TokenDefinition matchTokenDefinition(string source, int currentIndex, out int matchLength)
        {
            foreach (var rule in this.tokenDefinitions)
            {
                var match = rule.Regex.Match(source, currentIndex);

                if (match.Success && match.Index == currentIndex)
                {
                    matchLength = match.Length;
                    return rule;
                }
            }
            matchLength = 0;
            return null;
        }
    }
}
