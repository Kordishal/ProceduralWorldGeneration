using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class SetName : MythAction
    {
        public SetName() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if ((taker.CurrentCreationState.isConnected || taker.CurrentCreationState.hasPower)&& !taker.CurrentCreationState.hasName)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.isCreatingPlane)
            {
                taker.PlaneConstruction.Name = "Plane " + taker.PlaneConstruction.Identifier;
            }
            else if (taker.CurrentCreationState.isCreatingDeity)
            {
                taker.DeityCreation.Name = "Deity " + taker.DeityCreation.Identifier;
            }
            taker.CurrentCreationState.hasName = true;
        }
    }
}
