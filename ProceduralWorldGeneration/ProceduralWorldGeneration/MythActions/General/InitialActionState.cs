using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions;

namespace ProceduralWorldGeneration.MythActions.General
{
    class InitialActionState : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {

        }

        protected override void AdjustWeight(ActionTakerMythObject taker)
        {
            _weight = 0;
        }
    }
}
