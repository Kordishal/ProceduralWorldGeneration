using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;

namespace ProceduralWorldGeneration.MythActions.CreateSapientSpeciesActions
{
    class SetInnatePower : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.CreatedSapientSpecies.InnatePower = ConfigValues.RandomGenerator.Next(10);
        }
    }
}
