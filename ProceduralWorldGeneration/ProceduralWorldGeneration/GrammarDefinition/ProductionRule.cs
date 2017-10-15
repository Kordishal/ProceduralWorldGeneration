namespace ProceduralWorldGeneration.GrammarDefinition
{
    /// <summary>
    /// The production rule defines the behaviour of the grammar. 
    /// It defines how an input character is translated into output characters.
    /// </summary>
    public class ProductionRule
    {
        private char _initial_symbol { get; set; }
        private string _end_symbol { get; set; }

        // In the case that multiple rules can be chosen, the weight influences the random selection of the next rule.
        public int Weight { get; set; }

        // Determines whether this is a terminal rule. Terminal rules begin with a low weight, which increases as the production continues.
        public bool IsTerminalRule { get; set; }

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
            IsTerminalRule = is_terminal;
        }

        public string ReplaceSymbol(char c)
        {
            if (c == _initial_symbol)
                return _end_symbol;
            else
                return null;
        }


        public bool IsValidProductionRule(char input)
        {
            if (_initial_symbol == input)
                return true;
            else
                return false;
        }      
    }
}
