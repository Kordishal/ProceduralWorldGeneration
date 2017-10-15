using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.GrammarDefinition
{
    /// <summary>
    /// The Creation Myth Grammar is used to define the creation string.
    /// The creation string is then used to guide what types of myth objects are created by whom.
    /// It does not state any details about the myth objects only their type is defined.
    /// </summary>
    public class MythCreationGrammar
    {
        // The symbol to start the result string.
        private char _start_symbol { get; set; }

        // Terminals are valid characters which are no longer produced.
        private List<char> _terminals { get; set; }

        // Non-terminals are valid characters which need to be produced.
        private List<char> _non_terminals { get; set; }

        // The rules by which non-terminals are changed in each production cycle.
        private List<ProductionRule> _production_rules { get; set; }

        private int production_cycle_count { get; set; }

        // The resulting string after X production cycles.
        public string Result { get; set; }

        public MythCreationGrammar()
        {
            _start_symbol = 'X';
            _terminals = new List<char>() {'x', 'v', 'f', 'p', 'w', 'd', 's', 'a', 'e', 'c', 'n', 'm', 'l' };
            _non_terminals = new List<char>() {'X', 'F', 'P', 'W', 'D', 'S', 'A', 'E', 'C', 'N', 'M', 'L' };
            _production_rules = new List<ProductionRule>();

            production_cycle_count = Program.GeneratorConfigurations.ProductionCycleCount;
            Result = _start_symbol.ToString();
        }

        public void initialiseProductionRules()
        {
            // Start
            _production_rules.Add(new ProductionRule('X', "xfPPPFFFFF", 10));

            // Primordial Forces
            _production_rules.Add(new ProductionRule('F', "FF", 10));
            _production_rules.Add(new ProductionRule('F', "fP", 10));
            _production_rules.Add(new ProductionRule('F', "fD", 10));
            // Planes
            _production_rules.Add(new ProductionRule('P', "PP", 10));
            _production_rules.Add(new ProductionRule('P', "pW", 10));
            _production_rules.Add(new ProductionRule('P', "pA", 10));
            // World
            _production_rules.Add(new ProductionRule('W', "WW", 10));
            _production_rules.Add(new ProductionRule('W', "wD", 10));
            _production_rules.Add(new ProductionRule('W', "wS", 10));
            // Deities
            _production_rules.Add(new ProductionRule('D', "DD", 10));
            _production_rules.Add(new ProductionRule('D', "dA", 10));
            // Pre Sentient Species
            _production_rules.Add(new ProductionRule('S', "SS", 10));
            _production_rules.Add(new ProductionRule('S', "sE", 10));
            // Sentien Species
            _production_rules.Add(new ProductionRule('E', "EE", 10));
            _production_rules.Add(new ProductionRule('E', "eA", 10));
            // Sapient Species
            _production_rules.Add(new ProductionRule('A', "AA", 10));
            _production_rules.Add(new ProductionRule('A', "aC", 10));
            // Mythical Individuals
            _production_rules.Add(new ProductionRule('M', "MM", 10));
            _production_rules.Add(new ProductionRule('M', "mC", 10));
            _production_rules.Add(new ProductionRule('M', "mvD", 10));
            // Legendary Individual
            _production_rules.Add(new ProductionRule('L', "LL", 10));
            _production_rules.Add(new ProductionRule('L', "lN", 10));
            _production_rules.Add(new ProductionRule('L', "lvM", 10));
            // Civilisation
            _production_rules.Add(new ProductionRule('C', "CC", 10));
            _production_rules.Add(new ProductionRule('C', "cM", 10));
            _production_rules.Add(new ProductionRule('C', "cL", 10));
            _production_rules.Add(new ProductionRule('C', "cN", 10));
            // Nation
            _production_rules.Add(new ProductionRule('N', "NN", 10));
            _production_rules.Add(new ProductionRule('N', "nL", 10));            
        }

        public void repeatProduction()
        {
            for (int i = 0; i < production_cycle_count; i++)
            {
                produce(i);
            }

        }

        public void produce(int production_cycle)
        {
            List<ProductionRule> valid_rules;
            ProductionRule rule;
            List<string> changed_characters = new List<string>();

            foreach (char c in Result)
            {
                valid_rules = searchProductionRules(c).ToList();

                if (valid_rules.Count > 0)
                {
                    rule = chooseRule(valid_rules, production_cycle);
                    changed_characters.Add(rule.ReplaceSymbol(c));
                }
                else
                {
                    changed_characters.Add(c.ToString());
                }

            }

            Result = "";
            foreach (string s in changed_characters)
            {
                Result += s;
            }
        }

        private IEnumerable<ProductionRule> searchProductionRules(char input)
        {
            foreach (ProductionRule pr in _production_rules)
            {
                if (pr.IsValidProductionRule(input))
                {
                    yield return pr;
                }
            }
        }


        private ProductionRule chooseRule(List<ProductionRule> valid_rules, int production_cycle)
        {
            int count = valid_rules.Count;
            int total_weight = 0;

            // accumulate total weight
            foreach (ProductionRule pr in valid_rules)
            {
                if (pr.IsTerminalRule)
                {
                    pr.Weight = pr.Weight + (production_cycle / 10);
                }

                total_weight += pr.Weight;       
            }

            // pick first primordial power. There needs to be always at least one as otherwise nothing will be created.
            int chance = ConfigValues.Random.Next(total_weight);
            int current_weight = 0;
            foreach (ProductionRule pr in valid_rules)
            {
                current_weight += pr.Weight;
                if (chance < current_weight)
                {
                    return pr;
                }
            }


            return null;
        }
    }
}
