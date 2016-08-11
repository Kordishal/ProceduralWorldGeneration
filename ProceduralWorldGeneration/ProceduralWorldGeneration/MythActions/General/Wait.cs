using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.General
{
    class Wait : MythAction
    {
        protected override void AdjustWeight(ActionTakerMythObject taker)
        {
            _weight = 0;
        }

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            // WAIT
        }

        public Wait() {
            Cooldown = 0;
            Duration = 0;
        }
    }
}
