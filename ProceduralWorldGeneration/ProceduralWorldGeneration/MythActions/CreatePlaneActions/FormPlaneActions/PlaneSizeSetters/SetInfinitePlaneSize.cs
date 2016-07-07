using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters
{
    class SetInfinitePlaneSize : SetPlaneSize
    {

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (!taker.CurrentCreationState.hasType)
                return false;

            if (taker.PlaneConstruction.PlaneType.isAttachedTo != null)
                return false;
            else
                return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.PlaneConstruction.PlaneSize = searchSize("infinite");
            taker.CurrentCreationState.hasSize = true;
        }



    }
}
