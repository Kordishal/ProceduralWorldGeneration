using ProceduralWorldGeneration.Parser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser.LexerDefinition
{
    public interface ILexer
    {
        void AddDefinition(TokenDefinition tokenDefinition);
        IEnumerable<Token> Tokenize(string source);
    }
}
