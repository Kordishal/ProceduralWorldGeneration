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
using ProceduralWorldGeneration.MythActions.CreatePlaneActions;
using ProceduralWorldGeneration.Parser.SyntaxTree;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneTypeSetters;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneElementSetters;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.ConnectPlaneActions;
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

        public PrimordialForce(string tag = "default_tag") : base(tag)
        {
        }

        public override void takeAction(CreationMythState state, int current_year)
        {
            progressCooldowns();

            if (CurrentAction == null)
                determineNextAction(state);

            if (CurrentAction.getDuration() <= 0)
            {
                CreationMythLogger.updateActionLog(this);
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

        public override string ToString()
        {
            return "[" + Name + "]";
        }
    }
}
