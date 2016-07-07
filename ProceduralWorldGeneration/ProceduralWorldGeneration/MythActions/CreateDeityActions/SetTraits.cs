using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreateDeityActions
{
    class SetTraits : MythAction
    {
        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasDomains && !taker.CurrentCreationState.hasTraits)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
        }
    }
}
