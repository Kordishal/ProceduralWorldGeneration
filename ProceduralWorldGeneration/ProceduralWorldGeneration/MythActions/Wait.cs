﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions
{
    class Wait : PrimitivMythAction
    {
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
