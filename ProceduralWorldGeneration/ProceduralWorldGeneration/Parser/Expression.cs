using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser
{
    /// <summary>
    /// An expression is the combination of a number of tokens which form a logical unit.
    /// </summary>
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
