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
            // Needs an creater to become active
            if (!taker.CurrentCreationState.hasCreator)
                return false;
            // Only becomes valid if at least o
            if (!taker.CurrentCreationState.formedPlane)
                return true;

            return false;
        }
    }
}
