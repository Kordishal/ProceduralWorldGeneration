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
    class EtherealPlaneConnection : ConnectPlanes
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (CreationMythState.Planes.Count <= 0)
                return false;

            if (taker.CreatedPlane.PlaneType.isAttachedTo != null)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            // Connect a attached plane type to its respective plane type.
            taker.CreatedPlane.connectPlane(searchPlaneType(taker.CreatedPlane.PlaneType.isAttachedTo));
            taker.CreatedPlane.PlaneSize = taker.CreatedPlane.NeighbourPlanes[0].PlaneSize;
        }
    }
}
