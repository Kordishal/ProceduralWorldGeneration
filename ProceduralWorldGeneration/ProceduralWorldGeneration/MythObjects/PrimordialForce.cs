using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythActions;

namespace ProceduralWorldGeneration.MythObjects
{
    class PrimordialForce : ActionTakerMythObject
    {
        public static string TYPE = "PrimordialForce";

        public bool HasGatheredPower { get; set; }

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

        public override void addPossibleActions()
        {
            _possible_actions.Add(new GatherPower());
            _possible_actions.Add(new CreatePlane());
            _possible_actions.Add(new CreateCorePlane());
        }


        public PrimordialForce() : base()
        {
            base.Type = TYPE;
            HasGatheredPower = false;
        }

        public override void takeAction(CreationMythState state, int current_year)
        {
            if (CurrentAction != null)
            {
                if (CurrentAction.getDuration() <= 0)
                {
                    CurrentAction.Effect(state, this);
                    CurrentAction.resetCooldown();
                    CurrentAction.resetDuration();
                    CurrentAction = null;
                }
                else
                {
                    CurrentAction.reduceDuration();
                }
            }
            else
            {
                determineNextAction(state);
            }

        }

        public override string ToString()
        {
            return Name + "          { Opposing : " + (Opposing == null ? "NONE" : Opposing) + " }";
        }
    }
}
