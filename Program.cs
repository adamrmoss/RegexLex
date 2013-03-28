using System;
using System.Text.RegularExpressions;

namespace SimpleLexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var lexer = new Lexer();

            lexer.AddDefinition(new TokenDefinition(
                "(operator)",
                new Regex(@"\*|\/|\+|\-")));

            lexer.AddDefinition(new TokenDefinition(
                "(literal)",
                new Regex(@"\d+")));


            lexer.AddDefinition(new TokenDefinition(
                "(white-space)",
                new Regex(@"\s+"),
                true));

            var tokens = lexer.Tokenize("1 * 2 / 3 + 4 - 5");
            
            foreach (var token in tokens)
                Console.WriteLine(token);

            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
