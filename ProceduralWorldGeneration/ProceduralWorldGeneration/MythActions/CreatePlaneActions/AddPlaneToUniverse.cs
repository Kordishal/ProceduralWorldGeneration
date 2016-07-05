using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class AddPlaneToUniverse : MythAction
    {

        public AddPlaneToUniverse() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            if (taker.GetType() == typeof(PrimordialForce))
            {
                PrimordialForce _taker = (PrimordialForce)taker;
                if (_taker.PlaneConstructionState.hasName && !_taker.PlaneConstructionState.isAddedToUniverse)
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
            state.MythObjects.Add(_taker.PlaneConstruction);
            state.Planes.Add(_taker.PlaneConstruction);
            _taker.PlaneConstructionState = new CreatePlaneCreationState();
            _taker.PlaneConstruction = null;
        }
    }
}
