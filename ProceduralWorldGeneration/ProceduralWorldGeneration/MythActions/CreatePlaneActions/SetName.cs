using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class SetName : PrimitivMythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasName)
                return false;

            if (taker.CurrentCreationState.isConnected || taker.CurrentCreationState.hasPower)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
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
