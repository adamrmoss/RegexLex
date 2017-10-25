using System;
using System.Text.RegularExpressions;

namespace RegexLex
{
    public class TokenDefinition
    {
        public string Type { get; set; }
        public Regex Regex { get; set; }
        public bool IsIgnored { get; set; }
    }
}
