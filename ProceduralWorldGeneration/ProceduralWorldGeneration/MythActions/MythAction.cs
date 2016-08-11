using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythActions.General;
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

        protected int _weight;
        virtual protected void AdjustWeight(ActionTakerMythObject taker)
        {
            _weight = 10;
        }
        public int getWeight(ActionTakerMythObject taker)
        {
            AdjustWeight(taker);
            return _weight > 0 ? _weight : 0;
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

        abstract public bool checkPrecondition(ActionTakerMythObject taker);

        abstract public void Effect(ActionTakerMythObject taker);

        public MythAction()
        {
            // set name of action to its type - namespace
            string[] temp = GetType().ToString().Split('.');
            Name = temp[temp.Length - 1];
        }

        public override string ToString()
        {
            return Name + "[D:" + getDuration().ToString() + "]";
        }

        public override bool Equals(object obj)
        {
            return ((MythAction)obj).Name == this.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
