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
    class ConnectWithRandomPlane : ConnectPlane
    {
        public ConnectWithRandomPlane()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            if (!(CreationMythState.Planes.Count <= 0))
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            _taker.PlaneConstruction.connectPlane(CreationMythState.Planes[ConfigValues.RandomGenerator.Next(CreationMythState.Planes.Count)]);
            _taker.CurrentCreationState.isConnected = true;
        }
    }
}
