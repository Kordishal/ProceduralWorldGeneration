using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;


namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneElementSetters
{
    class SetNoElement : MythAction
    {
        public SetNoElement()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            if (!_taker.PlaneConstruction.PlaneType.hasDominantElement)
                return true;
            else
                return false;

        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            _taker.PlaneConstructionState.hasElement = true;
        }
    }
}
