using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions
{
    public abstract class MythAction
    {

        public string Name { get; set; }

        virtual public int getWeight(CreationMythState state, BaseMythObject taker)
        {
            return 10;
        }

        protected bool _is_primitve;
        public bool isPrimitive
        {
            get
            {
                return _is_primitve;
            }
            set
            {
                _is_primitve = value;
            }
        }

        protected int _cooldown = 0;
        protected int _passed_cooldown;
        /// <summary>
        /// Set/Get the cooldown period of this action once completed. It cannot be retaken until this period is elapsed.
        /// </summary>
        public int Cooldown
        {
            get
            {
                return _cooldown;
            }
            set
            {
                _cooldown = value;
            }
        }

        virtual public int getCurrentCooldown()
        {
            return _cooldown - _passed_cooldown;
        }
        virtual public void progressCooldown()
        {
            _passed_cooldown = _passed_cooldown + 1;
        }
        virtual public void resetCooldown()
        {
            _passed_cooldown = 0;
        }
        virtual public bool onCooldown()
        {
            return getCurrentCooldown() > 0;
        }

        protected int _duration = 1;
        protected int _passed_duration;
        /// <summary>
        /// Set/Get the duration for this action to complete.
        /// </summary>
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
            }
        }

        virtual public int getDuration()
        {
            return _duration - _passed_duration;
        }
        virtual public void reduceDuration()
        {
            _passed_duration += 1;
        }
        virtual public void resetDuration()
        {
            _passed_duration = 0;
        }

        abstract public bool checkPrecondition(CreationMythState state, BaseMythObject taker);

        abstract public void Effect(CreationMythState state, BaseMythObject taker);

        protected ActionGoal _reachable_goal;
        public ActionGoal ReachableGoal
        {
            get { return _reachable_goal; }
            set { _reachable_goal = value; }
        }

        public MythAction()
        {
            string[] temp = GetType().ToString().Split('.');
            Name = temp[temp.Length - 1];
            _is_primitve = false;
        }

        public override string ToString()
        {
            return Name + "[D:" + getDuration().ToString() + "]";
        }
    }
}
