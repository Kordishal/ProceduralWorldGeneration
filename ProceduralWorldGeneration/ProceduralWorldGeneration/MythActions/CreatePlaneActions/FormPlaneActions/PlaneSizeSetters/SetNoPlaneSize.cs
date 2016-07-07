using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters
{
    class SetNoPlaneSize : SetPlaneSize
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (!taker.CurrentCreationState.hasType)
                return false;

            if (taker.PlaneConstruction.PlaneType.isAttachedTo != null)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.CurrentCreationState.hasSize = true;
        }
    }
}
