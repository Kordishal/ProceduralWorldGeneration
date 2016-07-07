using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class CreatePlane : NonPrimitiveMythAction
    {

        public CreatePlane() : base()
        {
            _reachable_goal = ActionGoal.CreatePlane;
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
