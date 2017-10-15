using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.Output;
using ProceduralWorldGeneration.MythActions;
using ProceduralWorldGeneration.MythActions.General;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.ConnectPlaneActions;
using ProceduralWorldGeneration.MythActions.CreateDeityActions;

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
                    NotifyPropertyChanged("SpawnWeight");
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
                    NotifyPropertyChanged("Opposing");
                }
            }
        }

        public PrimordialForce(string tag = Constants.SpecialTags.DEFAULT_TAG) : base(tag)
        {
            
        }

        public override void takeAction(int current_year)
        {
            if (CurrentGoal == ActionGoal.None)
                determineNextGoal();

            if (CurrentAction.getDuration() <= 0)
            {
                CreationMythLogger.UpdateActionLog(this);
                CurrentAction.resetDuration();
                determineNextAction();              
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

        protected override void setStateTransitions()
        {
            AddTransition(new InitialActionState(), new SetCreator());

            AddTransition(new SetCreator(), new SetPlaneType());
            AddTransition(new SetCreator(), new SetPrimaryDomain());

            AddTransition(new SetPlaneType(), new SetFinitePlaneSize());
            AddTransition(new SetPlaneType(), new SetNoPlaneSize());

            AddTransition(new SetFinitePlaneSize(), new SetPlaneElement());
            AddTransition(new SetFinitePlaneSize(), new SetNoPlaneElement());

            AddTransition(new SetNoPlaneSize(), new SetPlaneElement());
            AddTransition(new SetNoPlaneSize(), new SetNoPlaneElement());

            AddTransition(new SetPlaneElement(), new SetFirstConnection());
            AddTransition(new SetPlaneElement(), new EtherealPlaneConnection());
            AddTransition(new SetPlaneElement(), new AddNoConnection());

            AddTransition(new SetNoPlaneElement(), new SetFirstConnection());
            AddTransition(new SetNoPlaneElement(), new AddNoConnection());

            AddTransition(new SetFirstConnection(), new AddAdditionalConnection());
            AddTransition(new SetFirstConnection(), new SetName());

            AddTransition(new AddAdditionalConnection(), new AddAdditionalConnection());
            AddTransition(new AddAdditionalConnection(), new SetName());

            AddTransition(new AddNoConnection(), new SetName());

            AddTransition(new EtherealPlaneConnection(), new SetName());

            AddTransition(new SetName(), new AddToUniverse());

            AddTransition(new AddToUniverse(), new InitialActionState());

            // CREATE A DEITY  

            AddTransition(new SetPrimaryDomain(), new AddRandomDomain());

            AddTransition(new AddRandomDomain(), new AddRandomDomain());
            AddTransition(new AddRandomDomain(), new SetPower());

            AddTransition(new SetPower(), new SetPersonality());

            AddTransition(new SetPersonality(), new SetName());

        }
    }
}
