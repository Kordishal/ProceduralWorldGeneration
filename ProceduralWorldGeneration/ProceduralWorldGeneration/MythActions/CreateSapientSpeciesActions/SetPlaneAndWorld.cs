using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreateSapientSpeciesActions
{
    class SetPlaneAndWorld : MythAction
    {
        public SetPlaneAndWorld() : base()
        {
            _is_primitve = true;
        }


        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.isCreatingSapientSpecies && !taker.CurrentCreationState.hasPlaneAndWorld)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
        }
    }
}
