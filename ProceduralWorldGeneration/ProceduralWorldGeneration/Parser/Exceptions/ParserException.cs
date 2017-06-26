using ProceduralWorldGeneration.Parser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser.Exceptions
{

    /// <summary>
    /// The parser exception has a specific message related to where an unexpected token appeared during parsing.
    /// Is not very understandable implemented...
    /// </summary>
    class ParserException : Exception
    {
        private string _message;

        public ParserException(Token current_token) : base()
        {
            _message = "Unexpected Token encountered: " + current_token.Type + " with value " + current_token.Value + " at position {" + current_token.Position + "}\n";
        }

        public override string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
