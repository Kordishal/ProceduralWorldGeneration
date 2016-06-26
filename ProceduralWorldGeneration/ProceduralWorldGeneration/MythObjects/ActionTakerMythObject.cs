using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.Input;
using System.Collections.ObjectModel;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythActions;

namespace ProceduralWorldGeneration.MythObjects
{
    abstract class ActionTakerMythObject : BaseMythObject, IActionTaker
    {
        private MythAction _current_action;
        public MythAction CurrentAction
        {
            get
            {
                return _current_action;
            }

            set
            {
                _current_action = value;
            }
        }

        protected List<MythAction> _possible_actions;
        public List<MythAction> PossibleActions
        {
            get
            {
                return _possible_actions;
            }
        }

        public abstract void takeAction(CreationMythState creation_myth, int current_year);
        
        virtual public void addPossibleActions()
        {
            _possible_actions.Add(new Wait());
        }

        virtual public void determineNextAction(CreationMythState creation_myth, ActionTakerMythObject action_taker)
        {
            _current_action = _possible_actions[0];
        }

        public ActionTakerMythObject()
        {
            _possible_actions = new List<MythAction>();
            addPossibleActions();
        }
    }
}
