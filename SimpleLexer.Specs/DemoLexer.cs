using System;
using NUnit.Framework;
using SimpleLexer.Core;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace SimpleLexer.Specs
{
  [TestFixture]
  public class DemoLexer : AssertionHelper
  {
    private Lexer<string> lexer;
    private IEnumerable<Token<string>> tokens;

    [SetUp]
    public void SetUp()
    {
      lexer = new Lexer<string>();
      
      var operatorTokenDefinition = new TokenDefinition<string> {
        Type = "Operator",
        Regex = new Regex(@"\*|\/|\+|\-")
      };
      lexer.AddDefinition(operatorTokenDefinition);
      
      var literalTokenDefinition = new TokenDefinition<string> {
        Type = "Literal",
        Regex = new Regex(@"\d+")
      };
      lexer.AddDefinition(literalTokenDefinition);      

      var whitespaceTokenDefinition = new TokenDefinition<string> {
        Type = "Whitespace",
        Regex = new Regex(@"\s+"),
        IsIgnored = true
      };
      lexer.AddDefinition(whitespaceTokenDefinition);
      
      tokens = lexer.Tokenize("1 * 2 / 3 + 4 - 5");
    }

    [Test]
    public void First_1()
    {
      var first = tokens.ElementAt(0);
      
      Expect(first.Type, EqualTo("Literal"));
      Expect(first.Value, EqualTo("1"));
      Expect(first.Position.Index, EqualTo(0));
      Expect(first.Position.Line, EqualTo(1));
      Expect(first.Position.Column, EqualTo(0));
    }
    
    [Test]
    public void Second_Star()
    {
      var second = tokens.ElementAt(1);
      
      Expect(second.Type, EqualTo("Operator"));
      Expect(second.Value, EqualTo("*"));
      Expect(second.Position.Index, EqualTo(2));
      Expect(second.Position.Line, EqualTo(1));
      Expect(second.Position.Column, EqualTo(2));
    }

    [Test]
    public void Third_2()
    {
      var third = tokens.ElementAt(2);
      
      Expect(third.Type, EqualTo("Literal"));
      Expect(third.Value, EqualTo("2"));
      Expect(third.Position.Index, EqualTo(4));
      Expect(third.Position.Line, EqualTo(1));
      Expect(third.Position.Column, EqualTo(4));
    }
    
    [Test]
    public void Fourth_Foreslash()
    {
      var fourth = tokens.ElementAt(3);
      
      Expect(fourth.Type, EqualTo("Operator"));
      Expect(fourth.Value, EqualTo("/"));
      Expect(fourth.Position.Index, EqualTo(6));
      Expect(fourth.Position.Line, EqualTo(1));
      Expect(fourth.Position.Column, EqualTo(6));
    }

    [Test]
    public void Fifth_3()
    {
      var fifth = tokens.ElementAt(4);
      
      Expect(fifth.Type, EqualTo("Literal"));
      Expect(fifth.Value, EqualTo("3"));
      Expect(fifth.Position.Index, EqualTo(8));
      Expect(fifth.Position.Line, EqualTo(1));
      Expect(fifth.Position.Column, EqualTo(8));
    }
    
    [Test]
    public void Sixth_Plus()
    {
      var sixth = tokens.ElementAt(5);
      
      Expect(sixth.Type, EqualTo("Operator"));
      Expect(sixth.Value, EqualTo("+"));
      Expect(sixth.Position.Index, EqualTo(10));
      Expect(sixth.Position.Line, EqualTo(1));
      Expect(sixth.Position.Column, EqualTo(10));
    }

    [Test]
    public void Seventh_4()
    {
      var seventh = tokens.ElementAt(6);
      
      Expect(seventh.Type, EqualTo("Literal"));
      Expect(seventh.Value, EqualTo("4"));
      Expect(seventh.Position.Index, EqualTo(12));
      Expect(seventh.Position.Line, EqualTo(1));
      Expect(seventh.Position.Column, EqualTo(12));
    }
    
    [Test]
    public void Eighth_Minus()
    {
      var eighth = tokens.ElementAt(7);
      
      Expect(eighth.Type, EqualTo("Operator"));
      Expect(eighth.Value, EqualTo("-"));
      Expect(eighth.Position.Index, EqualTo(14));
      Expect(eighth.Position.Line, EqualTo(1));
      Expect(eighth.Position.Column, EqualTo(14));
    }
    
    [Test]
    public void Ninth_5()
    {
      var nineth = tokens.ElementAt(8);
      
      Expect(nineth.Type, EqualTo("Literal"));
      Expect(nineth.Value, EqualTo("5"));
      Expect(nineth.Position.Index, EqualTo(16));
      Expect(nineth.Position.Line, EqualTo(1));
      Expect(nineth.Position.Column, EqualTo(16));
    }
  }
}

