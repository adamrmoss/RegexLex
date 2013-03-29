using System;
using System.Text.RegularExpressions;

namespace SimpleLexer.Core
{
  public class TokenDefinition<TToken>
  {
    public TToken Type { get; set; }
    public Regex Regex { get; set; }
    public bool IsIgnored { get; set; }
  }
}
