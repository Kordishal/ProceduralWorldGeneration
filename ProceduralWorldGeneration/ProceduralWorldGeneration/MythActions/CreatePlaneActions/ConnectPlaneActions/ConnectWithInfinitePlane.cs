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
    class ConnectWithInfinitePlane : ConnectPlane
    {
        public ConnectWithInfinitePlane()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            if (!(state.Planes.Count <= 0))
            {
                if (searchPlaneSize(state.Planes, "infinite") != null)
                {
                    return true;
                }
                else
                    return false;
            }            
            else
                return false;
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            _taker.PlaneConstruction.connectPlane(searchPlaneSize(state.Planes, "infinite"));
            _taker.PlaneConstructionState.isConnected = true;
        }
    }
}

