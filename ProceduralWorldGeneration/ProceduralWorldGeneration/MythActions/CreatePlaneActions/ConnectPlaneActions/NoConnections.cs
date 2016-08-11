using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Constants;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.ConnectPlaneActions
{
    class NoConnections : ConnectPlanes
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            // In case of the core world it cannot be connected with anything as no other plane exists yet.
            if (taker.PlaneConstruction.Tag == SpecialTags.CORE_WORLD_TAG)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {

        }
    }
}
