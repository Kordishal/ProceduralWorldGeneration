using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Grammar
{
    /// <summary>
    /// A production rule indicates how to continue the grammar.
    /// </summary>
    class ProductionRule
    {
        public char InitialSymbol { get; set; }
        public string EndSymbols { get; set; }
        public int Weight { get; set; }

        public bool isTerminalRule { get; set; }

        public ProductionRule(char init, string replace, int weight, bool is_terminal = false)
        {
            InitialSymbol = init;
            EndSymbols = replace;
            Weight = weight;
            isTerminalRule = is_terminal;
        }

        public string replaceSymbol(char c)
        {
            if (c == InitialSymbol)
            {
                return EndSymbols;
            }
            else
            {
                return null;
            }
        }

        public bool isValidProductionRule(char input)
        {
            if (InitialSymbol == input)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
