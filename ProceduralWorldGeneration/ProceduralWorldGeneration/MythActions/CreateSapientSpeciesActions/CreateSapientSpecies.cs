using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreateSapientSpeciesActions
{
    class CreateSapientSpecies : NonPrimitiveMythAction
    {
        public CreateSapientSpecies()
        {
            _reachable_goal = ActionGoal.CreateSapientSpecies;
        }

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.GetType() == typeof(PrimordialForce))
                return true;
            else
                return false;
        }
    }
}
