using System;

namespace RegexLex
{
    public class Token
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public TokenPosition Position { get; set; }

        public override string ToString()
            => $"Token: {{ Type: \"{this.Type}\", Value: \"{this.Value}\", Position: {{ Index: \"{this.Position.Index}\", Line: \"{this.Position.Line}\", Column: \"{this.Position.Column}\" }} }}";
    }

    public class TokenPosition
    {
        public int Index { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }
}
