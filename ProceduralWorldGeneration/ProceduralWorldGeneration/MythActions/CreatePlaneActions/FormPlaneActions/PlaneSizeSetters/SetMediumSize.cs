using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjectAttributes;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters
{
    class SetMediumSize : MythAction
    {

        public SetMediumSize() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            if (_taker.PlaneConstruction.PlaneType.isAttachedTo == null)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            _taker.PlaneConstruction.PlaneSize = searchSize(state.MythObjectData.PlaneSizes);
            _taker.CurrentCreationState.hasSize = true;
        }


        private PlaneSize searchSize(List<PlaneSize> plane_sizes)
        {
            foreach (PlaneSize p in plane_sizes)
                if (p.Tag == "medium")
                    return p;
            return null;
        }
    }
}
