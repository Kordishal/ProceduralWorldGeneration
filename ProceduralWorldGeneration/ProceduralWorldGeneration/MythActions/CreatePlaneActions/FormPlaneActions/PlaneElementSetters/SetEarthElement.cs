using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneElementSetters
{
    class SetEarthElement : MythAction
    {
        public SetEarthElement()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            if (_taker.PlaneConstruction.PlaneType.hasDominantElement)
                return true;
            else
                return false;

        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            _taker.PlaneConstruction.PlaneElement = searchElement(state.MythObjectData.PlaneElements);
            _taker.CurrentCreationState.hasElement = true;
        }

        private PlaneElement searchElement(List<PlaneElement> plane_elements)
        {
            foreach (PlaneElement p in plane_elements)
                if (p.Tag == "earth")
                    return p;
            return null;
        }
    }
}
