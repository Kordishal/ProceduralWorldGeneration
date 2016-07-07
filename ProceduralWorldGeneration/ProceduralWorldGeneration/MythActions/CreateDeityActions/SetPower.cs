using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;

namespace ProceduralWorldGeneration.MythActions.CreateDeityActions
{
    class SetPower : PrimitivMythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasPersonality && !taker.CurrentCreationState.hasPower)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.DeityCreation.Power = ConfigValues.RandomGenerator.Next(10);
            taker.CurrentCreationState.hasPower = true;
        }
    }
}
