using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace RegexLex
{
    public class ExpressionLexer
    {
        private readonly IEnumerable<Token> tokens;

        public ExpressionLexer()
        {
            var lexer = new Lexer();

            var operatorTokenDefinition = new TokenDefinition {
                Type = "Operator",
                Regex = new Regex(@"\*|\/|\+|\-")
            };
            lexer.AddDefinition(operatorTokenDefinition);

            var literalTokenDefinition = new TokenDefinition {
                Type = "Literal",
                Regex = new Regex(@"\d+")
            };
            lexer.AddDefinition(literalTokenDefinition);

            var whitespaceTokenDefinition = new TokenDefinition {
                Type = "Whitespace",
                Regex = new Regex(@"\s+"),
                IsIgnored = true
            };
            lexer.AddDefinition(whitespaceTokenDefinition);

            this.tokens = lexer.Tokenize("1 * 2 / 3 + 4 - 5");
        }

        [Fact]
        public void First_1()
        {
            var first = this.tokens.ElementAt(0);

            Assert.Equal("Literal", first.Type);
            Assert.Equal("1", first.Value);
            Assert.Equal(0, first.Position.Index);
            Assert.Equal(1, first.Position.Line);
            Assert.Equal(0, first.Position.Column);
        }

        [Fact]
        public void Second_Star()
        {
            var second = this.tokens.ElementAt(1);

            Assert.Equal("Operator", second.Type);
            Assert.Equal("*", second.Value);
            Assert.Equal(2, second.Position.Index);
            Assert.Equal(1, second.Position.Line);
            Assert.Equal(2, second.Position.Column);
        }

        [Fact]
        public void Third_2()
        {
            var third = this.tokens.ElementAt(2);

            Assert.Equal("Literal", third.Type);
            Assert.Equal("2", third.Value);
            Assert.Equal(4, third.Position.Index);
            Assert.Equal(1, third.Position.Line);
            Assert.Equal(4, third.Position.Column);
        }

        [Fact]
        public void Fourth_Foreslash()
        {
            var fourth = this.tokens.ElementAt(3);

            Assert.Equal("Operator", fourth.Type);
            Assert.Equal("/", fourth.Value);
            Assert.Equal(6, fourth.Position.Index);
            Assert.Equal(1, fourth.Position.Line);
            Assert.Equal(6, fourth.Position.Column);
        }

        [Fact]
        public void Fifth_3()
        {
            var fifth = this.tokens.ElementAt(4);

            Assert.Equal("Literal", fifth.Type);
            Assert.Equal("3", fifth.Value);
            Assert.Equal(8, fifth.Position.Index);
            Assert.Equal(1, fifth.Position.Line);
            Assert.Equal(8, fifth.Position.Column);
        }

        [Fact]
        public void Sixth_Plus()
        {
            var sixth = this.tokens.ElementAt(5);

            Assert.Equal("Operator", sixth.Type);
            Assert.Equal("+", sixth.Value);
            Assert.Equal(10, sixth.Position.Index);
            Assert.Equal(1, sixth.Position.Line);
            Assert.Equal(10, sixth.Position.Column);
        }

        [Fact]
        public void Seventh_4()
        {
            var seventh = this.tokens.ElementAt(6);

            Assert.Equal("Literal", seventh.Type);
            Assert.Equal("4", seventh.Value);
            Assert.Equal(12, seventh.Position.Index);
            Assert.Equal(1, seventh.Position.Line);
            Assert.Equal(12, seventh.Position.Column);
        }

        [Fact]
        public void Eighth_Minus()
        {
            var eighth = this.tokens.ElementAt(7);

            Assert.Equal("Operator", eighth.Type);
            Assert.Equal("-", eighth.Value);
            Assert.Equal(14, eighth.Position.Index);
            Assert.Equal(1, eighth.Position.Line);
            Assert.Equal(14, eighth.Position.Column);
        }

        [Fact]
        public void Ninth_5()
        {
            var nineth = this.tokens.ElementAt(8);

            Assert.Equal("Literal", nineth.Type);
            Assert.Equal("5", nineth.Value);
            Assert.Equal(16, nineth.Position.Index);
            Assert.Equal(1, nineth.Position.Line);
            Assert.Equal(16, nineth.Position.Column);
        }
    }
}
