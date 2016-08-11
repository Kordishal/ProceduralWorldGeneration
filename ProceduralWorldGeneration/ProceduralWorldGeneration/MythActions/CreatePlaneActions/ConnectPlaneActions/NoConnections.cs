using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Constants;
using ProceduralWorldGeneration.DataStructure;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.ConnectPlaneActions
{
    class AddNoConnection : ConnectPlanes
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            // In case of the core world it cannot be connected with anything as no other plane exists yet.
            if (CreationMythState.Planes.Count <= 0)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {

        }
    }
}
