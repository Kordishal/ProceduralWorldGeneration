using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.Output;

namespace ProceduralWorldGeneration.MythObjects
{
    public class PrimordialForce : ActionTakerMythObject
    {
        private int _spawn_weight;
        public int SpawnWeight
        {
            get
            {
                return _spawn_weight;
            }
            set
            {
                if (_spawn_weight != value)
                {
                    _spawn_weight = value;
                    base.NotifyPropertyChanged("SpawnWeight");
                }
            }
        }

        private string _opposing;
        public string Opposing
        {
            get
            {
                return _opposing;
            }
            set
            {
                if (_opposing != value)
                {
                    _opposing = value;
                    base.NotifyPropertyChanged("Opposing");
                }
            }
        }

        public PrimordialForce(string tag = Constants.SpecialTags.DEFAULT_TAG) : base(tag)
        {
        }

        public override void takeAction(int current_year)
        {
            progressCooldowns();

            if (CurrentAction == null)
                determineNextAction();

            if (CurrentAction.getDuration() <= 0)
            {
                CreationMythLogger.updateActionLog(this);
                CurrentAction.Effect(this);
                CurrentAction.resetCooldown();
                CurrentAction.resetDuration();
                CurrentAction = null;
            }
            else
            {
                CurrentAction.reduceDuration();
            }
        }

        public override string ToString()
        {
            return "[" + Name + "]";
        }
    }
}
