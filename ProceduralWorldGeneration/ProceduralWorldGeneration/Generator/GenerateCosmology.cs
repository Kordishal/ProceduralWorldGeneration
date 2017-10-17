using ProceduralWorldGeneration.GrammarDefinition;
using ProceduralWorldGeneration.Main;
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
        public Random Random { get; set; }

        public Grammar Grammar { get; set; }

        public Cosmology Cosmology { get; set; }

        public GenerateCosmology(int seed)
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

                Result = "X"
            };

            Cosmology = new Cosmology();
            Random = new Random(seed);
        }

        public void GeneratePrimordialForces()
        {
            int nr_of_primordial_forces = Random.Next(1, 4);

            for (int i = 0; i < nr_of_primordial_forces; i++)
            {
                // if i is even add a random new force.
                if (i % 2 == 0)
                {
                    int total_spawn_weight = 0;
                    foreach (var prim_force in Program.DataLoadHandler.PrimordialForces)
                        total_spawn_weight += prim_force.SpawnWeight;

                    // Pick the first primordial force. Based on the weighting.
                    int rnd_value = Random.Next(total_spawn_weight);
                    int prev_weight = 0, current_weight = 0;
                    foreach (var prim_force in Program.DataLoadHandler.PrimordialForces)
                    {
                        current_weight += prim_force.SpawnWeight;
                        if (prev_weight <= rnd_value && rnd_value < current_weight)
                        {
                            Cosmology.PrimordialForces.Add(prim_force);
                            break;
                        }

                        prev_weight += prim_force.SpawnWeight;
                    }
                }
                // if i is odd add the opposite of the previously added force.
                else if (i % 2 == 1)
                {
                    foreach (var prim_force in Program.DataLoadHandler.PrimordialForces)
                        if (prim_force.OpposingForce == Cosmology.PrimordialForces[i - 1].Tag)
                            Cosmology.PrimordialForces.Add(prim_force);
                }
                // remove the added force from the pool of possible forces.
                Program.DataLoadHandler.PrimordialForces.Remove(Cosmology.PrimordialForces[i]);
            }
        }

        public void GenerateCreationString()
        {
            Grammar.RepeatUntilFullyTerminal();
            Program.Debugger.DebugMessagesList.Add(Grammar.Result + "\n");
        }


    }
}
