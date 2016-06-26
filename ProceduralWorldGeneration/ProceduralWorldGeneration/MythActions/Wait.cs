using System;
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
        public override int getCurrentCooldown(CreationMythState state, BaseMythObject taker)
        {
            _current_cooldown += 1;
            return _total_cooldown - _current_cooldown;
        }

        public override int getweight(CreationMythState state, BaseMythObject taker)
        {
            return _weight;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            return true;
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            // WAIT
        }

        public Wait() { }

        public Wait(int cooldown, int weight)
        {
            _weight = weight;
            _total_cooldown = cooldown;
        }
    }
}
