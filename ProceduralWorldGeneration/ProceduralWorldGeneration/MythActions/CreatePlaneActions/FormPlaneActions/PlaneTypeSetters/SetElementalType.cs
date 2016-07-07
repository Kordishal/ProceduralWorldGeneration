using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneTypeSetters
{
    class SetElementalType : MythAction
    {
        public SetElementalType() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if (state.Planes.Count > 0)
                return true;
            else
                return false; ;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            _taker.PlaneConstruction.PlaneType = searchPlaneType(state.MythObjectData.PlaneTypes);
            _taker.CurrentCreationState.hasType = true;
        }

        private PlaneType searchPlaneType(List<PlaneType> plane_types)
        {
            foreach (PlaneType p in plane_types)
                if (p.Tag == "elemental")
                    return p;
            return null;
        }
    }
}
