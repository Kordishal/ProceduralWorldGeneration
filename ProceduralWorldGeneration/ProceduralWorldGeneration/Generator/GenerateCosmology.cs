using ProceduralWorldGeneration.GrammarDefinition;
using ProceduralWorldGeneration.Universe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    class GenerateCosmology
    {
        public Grammar Grammar { get; set; }

        public Cosmology Cosmology { get; set; }

        public GenerateCosmology()
        {
            Grammar = new Grammar(10000)
            {
                StartSymbol = 'X',
                NonTerminals = new List<char>() { 'F', 'P', 'D' },
                Terminals = new List<char>() { 'f', 'p', 'd' },

                ProductionRules = new List<ProductionRule>()
                {
                    new ProductionRule('X', "xF", 100),
                    new ProductionRule('X', "xFF", 50),
                    new ProductionRule('X', "xFFF", 10),
                    
                    new ProductionRule('F', "FF", 100),
                    new ProductionRule('F', "FFF", 50),
                    new ProductionRule('F', "FFFF", 10),
                    
                    new ProductionRule('F', "fp", 50, true),
                    new ProductionRule('F', "fd", 50, true),
                },
            };

            Cosmology = new Cosmology();
        }

        public void Generate()
        {
            


        }


    }
}
