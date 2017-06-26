using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Grammar
{
    /// <summary>
    /// The production rule defines the behaviour of the grammar. 
    /// It defines how an input character is translated into output characters.
    /// </summary>
    public class ProductionRule
    {
        private char _initial_symbol { get; set; }
        private string _end_symbol { get; set; }

        // Used to control how likely it is for a production rule to be chosen 
        // when several valid are available.
        public int Weight { get; set; }

        public bool isTerminalRule { get; set; }

        /// <summary>
        /// Create a production rule.
        /// </summary>
        /// <param name="init">The non-terminal symbol to be replaced.</param>
        /// <param name="replace">A string of symbols which replace the initial symbol.</param>
        /// <param name="weight">The likely hood of this rule to be used, if several are available. The higher the weight the bigger the chance.</param>
        /// <param name="is_terminal">Indicates that all the end symbols are terminal symbols.</param>
        public ProductionRule(char init, string replace, int weight, bool is_terminal = false)
        {
            _initial_symbol = init;
            _end_symbol = replace;
            Weight = weight;
            isTerminalRule = is_terminal;
        }

        public string replaceSymbol(char c)
        {
            if (c == _initial_symbol)
                return _end_symbol;
            else
                return null;
        }


        public bool isValidProductionRule(char input)
        {
            if (_initial_symbol == input)
                return true;
            else
                return false;
        }      
    }
}
