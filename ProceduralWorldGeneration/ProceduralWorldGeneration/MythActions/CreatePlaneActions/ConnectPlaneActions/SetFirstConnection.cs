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
            if (taker.PlaneConstruction.PlaneSize == null)
                return false;
            if (CreationMythState.Planes.Count > 0)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            // try to connect any plane first to an infinite plane. If this does not exist connect it to the core world.
            Plane temp_plane = searchPlaneSize("infinite");
            if (temp_plane != null)
                taker.PlaneConstruction.connectPlane(temp_plane);
            else
                taker.PlaneConstruction.connectPlane(CreationMythState.Planes[0]);

            taker.CurrentCreationState.hasFirstConnection = true;

            if (taker.PlaneConstruction.maxConnectionsReached())
                taker.CurrentCreationState.isConnected = true;
        }
    }
}

