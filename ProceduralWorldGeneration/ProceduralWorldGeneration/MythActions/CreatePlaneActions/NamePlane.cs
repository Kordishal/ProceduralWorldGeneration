using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class NamePlane : MythAction
    {
        public NamePlane() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            if (taker.GetType() == typeof(PrimordialForce))
            {
                PrimordialForce _taker = (PrimordialForce)taker;
                if (_taker.PlaneConstructionState.isConnected && !_taker.PlaneConstructionState.hasName)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            _taker.PlaneConstruction.Name = "Hello World";
            _taker.PlaneConstructionState.hasName = true;
        }
    }
}
