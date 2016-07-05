using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters
{
    class SetPocketSize : MythAction
    {

        public SetPocketSize() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            if (_taker.PlaneConstruction.PlaneType.isAttachedTo == null)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            _taker.PlaneConstruction.PlaneSize = searchSize(state.MythObjectData.PlaneSizes);
            _taker.PlaneConstructionState.hasSize = true;
        }


        private PlaneSize searchSize(List<PlaneSize> plane_sizes)
        {
            foreach (PlaneSize p in plane_sizes)
                if (p.Tag == "pocket")
                    return p;
            return null;
        }
    }
}
