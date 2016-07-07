using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreateSapientSpeciesActions
{
    class CreateSapientSpecies : MythAction
    {

        public CreateSapientSpecies()
        {
            _reachable_goal = ActionGoal.CreateSapientSpecies;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if (taker.GetType() == typeof(PrimordialForce))
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {

        }
    }
}
