using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class ConnectPlane : NonPrimitiveMythAction 
    {

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.formedPlane && !taker.CurrentCreationState.isConnected)
                return true;
            else
                return false;

        }
    }
}
