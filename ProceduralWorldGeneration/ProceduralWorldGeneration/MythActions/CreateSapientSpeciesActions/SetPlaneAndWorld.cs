using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreateSapientSpeciesActions
{
    class SetPlaneAndWorld : PrimitivMythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.isCreatingSapientSpecies && !taker.CurrentCreationState.hasPlaneAndWorld)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
        }
    }
}
