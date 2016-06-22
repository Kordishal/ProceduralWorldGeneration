using ProceduralWorldGeneration.Input.LexerDefinition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Input
{
    class MythCreationLexer
    {

        public Lexer Lexer;

        public MythCreationLexer()
        {
            Lexer = new Lexer();

            foreach (TokenDefinition td in TokenDefinitions())
            {
                Lexer.AddDefinition(td);
            }

        }

        public IEnumerable<Token> GetTokens(string path)
        {
            string source = ReadFile(path);
            return Lexer.Tokenize(source);
        }


        private List<TokenDefinition> TokenDefinitions()
        {
            List<TokenDefinition> definitions = new List<TokenDefinition>();

            definitions.Add(new TokenDefinition(new Regex(@"#t"), "TRUE"));
            definitions.Add(new TokenDefinition(new Regex(@"#f"), "FALSE"));

            definitions.Add(new TokenDefinition(new Regex(@"\{"), "OPENING_CURLY_BRACES"));
            definitions.Add(new TokenDefinition(new Regex(@"\}"), "CLOSING_CURLY_BRACES"));

            definitions.Add(new TokenDefinition(new Regex(@"\["), "OPENING_SQUARE_BRACES"));
            definitions.Add(new TokenDefinition(new Regex(@"\]"), "CLOSING_SQUARE_BRACES"));

            definitions.Add(new TokenDefinition(new Regex(@"\="), "ASSIGNMENT"));

            definitions.Add(new TokenDefinition(new Regex(@"([""'])(?:\\\1|.)*?\1"), "STRING"));
            definitions.Add(new TokenDefinition(new Regex(@"[-+]?\d+"), "INTEGER"));

            definitions.Add(new TokenDefinition(new Regex(@"[*<>\?\-+/A-Za-z->!_]+"), "VARIABLE"));

            definitions.Add(new TokenDefinition(new Regex(@"\s+"), "WHITE_SPACE", true));
            definitions.Add(new TokenDefinition(new Regex(@"[\t]"), "TAB", true));

            return definitions;
        }




        private string ReadFile(string path)
        {
            string result = "";
            StreamReader reader = new StreamReader(path);

            while (!reader.EndOfStream)
            {
                result += reader.ReadLine();
            }

            reader.Close();
            return result;
        }

    }
}
