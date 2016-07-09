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
            // No longer execute this once the first connection has been set.
            if (taker.CurrentCreationState.hasFirstConnection)
                return false;

            // Do not take any ethereal planes
            if (taker.PlaneConstruction.PlaneSize == null)
                return false;

            // Do not take any pocket worlds.
            if (taker.PlaneConstruction.PlaneSize.MaxNeighbourPlanes == 1)
                return false;

            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            // In case of the core world it cannot be connected with anything as no other plane exists yet.
            if (taker.PlaneConstruction.Tag == SpecialTags.CORE_WORLD_TAG)
            {
                taker.CurrentCreationState.isConnected = true;
                return;
            }
            // the travel dimension is connected to the core world.
            else if (taker.PlaneConstruction.Tag == SpecialTags.TRAVEL_DIMENSION_TAG)
            {
                taker.PlaneConstruction.connectPlane(searchPlaneTag(SpecialTags.CORE_WORLD_TAG));
            }
            else
            {
                // Connect every plane with the travel dimension.
                taker.PlaneConstruction.connectPlane(searchPlaneTag(SpecialTags.TRAVEL_DIMENSION_TAG));
            }

            taker.CurrentCreationState.hasFirstConnection = true;
        }
    }
}

