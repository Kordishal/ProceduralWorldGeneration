﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions
{
    class Wait : MythAction
    {


        public override int getWeight(CreationMythState state, BaseMythObject taker)
        {
            return 0;
        }


        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            return true;
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            // WAIT
        }

        public Wait() {
            Cooldown = 0;
            Duration = 0;
            _is_primitve = true;
        }
    }
}
