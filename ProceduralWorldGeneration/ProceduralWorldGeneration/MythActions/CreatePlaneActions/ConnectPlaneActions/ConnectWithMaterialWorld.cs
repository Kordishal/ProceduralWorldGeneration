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
    class ConnectWithMaterialWorld : ConnectPlane
    {
        public ConnectWithMaterialWorld()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            if (!(state.Planes.Count <= 0))
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            _taker.PlaneConstruction.connectPlane(searchPlaneType(state.Planes, "material"));
            _taker.PlaneConstructionState.isConnected = true;
        }
    }
}
