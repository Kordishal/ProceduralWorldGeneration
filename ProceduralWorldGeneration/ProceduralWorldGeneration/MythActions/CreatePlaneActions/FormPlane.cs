using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class FormPlane : NonPrimitiveMythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            // Not used when the plane has formed.
            if (taker.CurrentCreationState.formedPlane)
                return false;

            // active as long as there is a creator
            if (taker.CurrentCreationState.hasCreator)
                return true;

            return false;
        }
    }
}
