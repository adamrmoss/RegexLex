using System;

namespace SimpleLexer.Core
{
  public class Token
  {
    public string Type { get; set; }
    public string Value { get; set; }
    public TokenPosition Position { get; set; }

    public override string ToString()
    {
      return string.Format("Token: {{ Type: \"{0}\", Value: \"{1}\", Position: {{ Index: \"{2}\", Line: \"{3}\", Column: \"{4}\" }} }}", Type, Value, Position.Index, Position.Line, Position.Column);
    }
  }

  public class TokenPosition
  {
    public int Index { get; set; }
    public int Line { get; set; }
    public int Column { get; set; }
  }
}
