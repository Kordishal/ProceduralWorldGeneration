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

        virtual public void determineNextAction(CreationMythState creation_myth)
        {
            List<MythAction> next_action_candidates = new List<MythAction>();
            int total_action_weight = 0;

            foreach (MythAction action in PossibleActions)
            {
                if (action.getCurrentCooldown() > 0)
                {
                    action.progressCooldown();
                }


                if (action.checkPrecondition(creation_myth, this) && action.getCurrentCooldown() <= 0)
                {
                    next_action_candidates.Add(action);
                    total_action_weight += action.getWeight(creation_myth, this);
                }
            }
            // If there are no valid candidates it will simply return a wait instruction.
            if (next_action_candidates.Count == 0)
            {
                _current_action = new Wait();
                return;
            }

            int chance = ConfigValues.RandomGenerator.Next(total_action_weight + 1);
            int prev_weight = 0, current_weight = next_action_candidates[0].getWeight(creation_myth, this);

            foreach (MythAction action in next_action_candidates)
            {
                if (prev_weight < chance && chance >= current_weight)
                {
                    _current_action = action;
                }
            }

            if  (_current_action == null)
            {
                _current_action = new Wait();
            }
        }

        public abstract void addPossibleActions();

        public ActionTakerMythObject()
        {
            _possible_actions = new List<MythAction>();
            addPossibleActions();
        }
    }
}
