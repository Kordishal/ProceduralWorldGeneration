using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions
{
    class DeterminePlaneSize : MythAction
    {
        public DeterminePlaneSize() : base()
        {
            _is_primitve = false;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            if (_taker.PlaneConstructionState.hasType && !_taker.PlaneConstructionState.hasSize)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {

        }
    }
}
