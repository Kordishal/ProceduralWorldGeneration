using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.GrammarDefinition
{
    class Grammar
    {
        // Random generator of this grammar.
        public Random Random { get; set; }

        // The symbol to start the result string.
        public char StartSymbol { get; set; }

        // Terminals are valid characters which are no longer produced.
        public List<char> Terminals { get; set; }

        // Non-terminals are valid characters which need to be produced.
        public List<char> NonTerminals { get; set; }

        // The rules by which non-terminals are changed in each production cycle.
        public List<ProductionRule> ProductionRules { get; set; }

        // The resulting string after X production cycles.
        public string Result { get; set; }

        public Grammar(int seed)
        {
            Random = new Random(seed);
        }

        public void RepeatedProduction(int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                Produce(i);
            }
        }

        public void Produce(int production_cycle)
        {
            List<ProductionRule> valid_rules;
            ProductionRule rule;
            List<string> changed_characters = new List<string>();

            foreach (char c in Result)
            {
                valid_rules = SearchValidProductionRules(c).ToList();

                if (valid_rules.Count > 0)
                {
                    rule = SelectRule(valid_rules, production_cycle);
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
        private IEnumerable<ProductionRule> SearchValidProductionRules(char input)
        {
            foreach (ProductionRule pr in ProductionRules)
                if (pr.IsValidProductionRule(input))
                    yield return pr;
        }


        private ProductionRule SelectRule(List<ProductionRule> valid_rules, int production_cycle)
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
            int chance = Random.Next(total_weight);
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
