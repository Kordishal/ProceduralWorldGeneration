using ProceduralWorldGeneration.Constants;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.ConnectPlaneActions
{
    class SetFirstConnection : ConnectPlanes
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (CreationMythState.Planes.Count <= 0)
                return false;

            // Do not take any ethereal planes
            if (taker.PlaneConstruction.PlaneSize == null)
                return false;

            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.PlaneConstruction.Tag == SpecialTags.TRAVEL_DIMENSION_TAG)
            {
                taker.PlaneConstruction.connectPlane(searchPlaneTag(SpecialTags.CORE_WORLD_TAG));
            }
            else if (taker.PlaneConstruction.PlaneSize.MaxNeighbourPlanes <= 1)
            {
                taker.PlaneConstruction.connectPlane(searchPlaneSize("large"));

            }
            else
            {
                // Connect every plane with the travel dimension.
                taker.PlaneConstruction.connectPlane(searchPlaneTag(SpecialTags.TRAVEL_DIMENSION_TAG));
            }
        }
    }
}

