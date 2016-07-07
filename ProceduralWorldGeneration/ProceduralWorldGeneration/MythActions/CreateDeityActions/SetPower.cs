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
    class SetPower : MythAction
    {
        public SetPower()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasPersonality && !taker.CurrentCreationState.hasPower)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            taker.DeityCreation.Power = ConfigValues.RandomGenerator.Next(10);
            taker.CurrentCreationState.hasPower = true;
        }
    }
}
