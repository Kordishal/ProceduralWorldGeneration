using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser
{
    class Expression
    {
        public ExpressionTypes ExpressionType { get; set; }
        public string ExpressionValue { get; set; }


        public override string ToString()
        {
            return ExpressionValue;
        }
    }

    enum ExpressionTypes
    {
        Root,
        Assignment,
        Variable,
        String,
        Integer,
        Range,
        Boolean,
    }
}
