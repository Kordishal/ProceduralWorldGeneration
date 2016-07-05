using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class SetCreator : MythAction
    {
        public SetCreator() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            if (taker.GetType() == typeof(PrimordialForce))
            {
                PrimordialForce _taker = (PrimordialForce)taker;
                if (!_taker.PlaneConstructionState.hasCreator)
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

            _taker.PlaneConstruction = new Plane();
            _taker.PlaneConstruction.Creator = _taker;
            _taker.PlaneConstructionState.hasCreator = true;
        }
    }
}
