using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions
{
    class SetNoPlaneSize : SetPlaneSize
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CreatedPlane.PlaneType.isAttachedTo != null)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {

        }
    }
}
