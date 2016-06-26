using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions
{
    abstract class MythAction
    {
        protected int _weight = 10;
        virtual public int getweight(CreationMythState state, BaseMythObject taker)
        {
            return _weight;
        }

        protected int _total_cooldown = 20;
        protected int _current_cooldown;
        virtual public int getCurrentCooldown(CreationMythState state, BaseMythObject taker)
        {
            return _total_cooldown - _current_cooldown;
        }
        virtual public void reduceCooldown(CreationMythState state, BaseMythObject take)
        {
            _current_cooldown = _current_cooldown - 1;
        }

        abstract public bool checkPrecondition(CreationMythState state, BaseMythObject taker);

        abstract public void Effect(CreationMythState state, BaseMythObject taker);


        public MythAction()
        {

        }

    }
}
