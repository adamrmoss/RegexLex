using System;
using System.Collections.Generic;

namespace SimpleLexer.Core
{
  public interface ILexer
  {
    void AddDefinition(TokenDefinition tokenDefinition);

    IEnumerable<Token> Tokenize(string source);
  }
}
