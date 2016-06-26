using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    class DeityGenerator
    {

        public Deity GeneratedDeity { get; set; }


        public DeityGenerator()
        {


        }


        public void generateDeity(CreationMythState creation_myth, BaseMythObject creator)
        {
            GeneratedDeity = new Deity();

            GeneratedDeity.PrimaryDomain = creation_myth.MythObjectData.Domains[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.Domains.Count)];

            GeneratedDeity.Name = "deity of " + GeneratedDeity.PrimaryDomain;

            creation_myth.MythObjects.Add(GeneratedDeity);
            creation_myth.ActionableMythObjects.Enqueue(GeneratedDeity);
            creation_myth.Logger.updateLog(GeneratedDeity, "CREADED");
        }
    }
}
