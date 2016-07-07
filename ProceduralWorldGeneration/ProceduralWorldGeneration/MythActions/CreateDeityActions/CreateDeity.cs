using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreateDeityActions
{
    class CreateDeity : NonPrimitiveMythAction
    {

        public CreateDeity() : base()
        {
            _reachable_goal = ActionGoal.CreateDeity;
        }

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            return true;
        }
    }
}
