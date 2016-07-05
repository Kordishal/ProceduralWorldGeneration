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
    class CreatePlane : MythAction
    {

        public CreatePlane() : base() {
            _is_primitve = false;
            _reachable_goal = ActionGoal.CreatePlane;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            if (taker.GetType() == typeof(PrimordialForce))
                return true;
            else
                return false;       
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {


        }
    }
}
