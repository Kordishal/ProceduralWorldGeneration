using ProceduralWorldGeneration.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Grammar
{
    class MythCreationGrammar
    {
        public char StartSymbol { get; set; }
        public List<char> Terminals { get; set; }
        public List<char> NonTerminals { get; set; }

        public List<ProductionRule> ProductionRules { get; set; }

        public string Result { get; set; }

        public MythCreationGrammar()
        {
            StartSymbol = 'X';
            Terminals = new List<char>() {'x', 'v', 'f', 'p', 'w', 'd', 's', 'a', 'e', 'c', 'n', 'm', 'l' };
            NonTerminals = new List<char>() {'X', 'F', 'P', 'W', 'D', 'S', 'A', 'E', 'C', 'N', 'M', 'L' };
            ProductionRules = new List<ProductionRule>();
            initialiseProductionRules();

            Result = StartSymbol.ToString();
        }

        private void initialiseProductionRules()
        {
            // Start
            ProductionRules.Add(new ProductionRule('X', "xfPPPFFFFF", 10));

            // Primordial Forces
            ProductionRules.Add(new ProductionRule('F', "FF", 10));
            ProductionRules.Add(new ProductionRule('F', "fP", 10));
            ProductionRules.Add(new ProductionRule('F', "fD", 10));
            // Planes
            ProductionRules.Add(new ProductionRule('P', "PP", 10));
            ProductionRules.Add(new ProductionRule('P', "pW", 10));
            ProductionRules.Add(new ProductionRule('P', "pA", 10));
            // World
            ProductionRules.Add(new ProductionRule('W', "WW", 10));
            ProductionRules.Add(new ProductionRule('W', "wD", 10));
            ProductionRules.Add(new ProductionRule('W', "wS", 10));
            // Deities
            ProductionRules.Add(new ProductionRule('D', "DD", 10));
            ProductionRules.Add(new ProductionRule('D', "dA", 10));
            // Pre Sentient Species
            ProductionRules.Add(new ProductionRule('S', "SS", 10));
            ProductionRules.Add(new ProductionRule('S', "sE", 10));
            // Sentien Species
            ProductionRules.Add(new ProductionRule('E', "EE", 10));
            ProductionRules.Add(new ProductionRule('E', "eA", 10));
            // Sapient Species
            ProductionRules.Add(new ProductionRule('A', "AA", 10));
            ProductionRules.Add(new ProductionRule('A', "aC", 10));
            // Mythical Individuals
            ProductionRules.Add(new ProductionRule('M', "MM", 10));
            ProductionRules.Add(new ProductionRule('M', "mC", 10));
            ProductionRules.Add(new ProductionRule('M', "mvD", 10));
            // Legendary Individual
            ProductionRules.Add(new ProductionRule('L', "LL", 10));
            ProductionRules.Add(new ProductionRule('L', "lN", 10));
            ProductionRules.Add(new ProductionRule('L', "lvM", 10));
            // Civilisation
            ProductionRules.Add(new ProductionRule('C', "CC", 10));
            ProductionRules.Add(new ProductionRule('C', "cM", 10));
            ProductionRules.Add(new ProductionRule('C', "cL", 10));
            ProductionRules.Add(new ProductionRule('C', "cN", 10));
            // Nation
            ProductionRules.Add(new ProductionRule('N', "NN", 10));
            ProductionRules.Add(new ProductionRule('N', "nL", 10));            
        }

        public void repeatProduction(int count)
        {
            for (int i = 0; i < count; i++)
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

                    changed_characters.Add(rule.replaceSymbol(c));
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
            foreach (ProductionRule pr in ProductionRules)
            {
                if (pr.isValidProductionRule(input))
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
                if (pr.isTerminalRule)
                {
                    pr.Weight = pr.Weight + (production_cycle / 10);
                }

                total_weight += pr.Weight;       
            }

            // pick first primordial power. There needs to be always at least one as otherwise nothing will be created.
            int chance = ConfigValues.RandomGenerator.Next(total_weight);
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
