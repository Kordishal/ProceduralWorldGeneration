using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.ConnectPlaneActions
{
    class ConnectWithNoPlane : ConnectPlanes
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (CreationMythState.Planes.Count <= 0)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.CurrentCreationState.isConnected = true;
        }
    }
}
