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
using ProceduralWorldGeneration.Parser.SyntaxTree;

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

        private ActionGoal _current_goal;
        public ActionGoal CurrentGoal
        {
            get
            {
                return _current_goal;
            }

            set
            {
                _current_goal = value;
            }
        }

        protected List<MythAction> _valid_actions;
        public List<MythAction> ValidActions
        {
            get
            {
                return _valid_actions;
            }
        }

        protected List<Tree<MythAction>> _existing_actions;
        public List<Tree<MythAction>> ExistingActions
        {
            get
            {
                return _existing_actions;
            }
        }

        public abstract void takeAction(CreationMythState creation_myth, int current_year);


        public void determineNextGoal(CreationMythState creation_myth)
        {
            _current_goal = ActionGoal.CreatePlane;
        }

        virtual public void determineNextAction(CreationMythState creation_myth)
        {
            Tree<MythAction> current_action_tree = null;
            MythAction local_action = null;
            List<TreeNode<MythAction>> next_action_candidates;
            int total_action_weight = 0;

            // if no goal is chosen a new one is determined.
            if (CurrentGoal == ActionGoal.None)
                determineNextGoal(creation_myth);

            // Set the current action tree according to the goal to be achieved.
            foreach (Tree<MythAction> action_tree in _existing_actions)
                if (action_tree.TreeRoot.Value.ReachableGoal == CurrentGoal)
                    current_action_tree = action_tree;

            // Assign the top action as local action. If the preconditions for this are not met then a wait is executed.
            if (current_action_tree.TreeRoot.Value.checkPrecondition(creation_myth, this))
            {
                local_action = current_action_tree.TreeRoot.Value;
                current_action_tree.CurrentNode = current_action_tree.TreeRoot;
            }          
            else
                local_action = new Wait();

            // Will run until we have a primitve function which can be called.
            while (!local_action.isPrimitive)
            {
                total_action_weight = 0;
                next_action_candidates = new List<TreeNode<MythAction>>();
                // Determines what children of the current action are valid actions.
                foreach (TreeNode<MythAction> action_node in current_action_tree.CurrentNode.Children)
                {
                    if (!action_node.Value.onCooldown() && action_node.Value.checkPrecondition(creation_myth, this))
                    {
                        total_action_weight += action_node.Value.getWeight(creation_myth, this);
                        next_action_candidates.Add(action_node);
                    }
                }



                int chance = ConfigValues.RandomGenerator.Next(total_action_weight + 1);
                int prev_weight = 0, current_weight = next_action_candidates[0].Value.getWeight(creation_myth, this);
                foreach (TreeNode<MythAction> action_node in next_action_candidates)
                {
                    // if chance is between the two weights the current action is chosen.
                    if (prev_weight < chance && chance <= current_weight)
                    {
                        local_action = action_node.Value;
                        current_action_tree.CurrentNode = action_node;
                    }

                    prev_weight = current_weight;
                    current_weight += action_node.Value.getWeight(creation_myth, this);
                }                
            }

            _current_action = local_action;

            if  (_current_action == null)
            {
                _current_action = new Wait();
            }
        }

        public abstract void buildExistingActionsTree();

        protected void progressCooldowns()
        {
            foreach (Tree<MythAction> tree in _existing_actions)
            {
                tree.TreeRoot.traverseTree(progressCooldowns);
            }
        }
        private void progressCooldowns(TreeNode<MythAction> myth_action)
        {
            if (myth_action.Value.getCurrentCooldown() > 0)
            {
                myth_action.Value.progressCooldown();
            }
        }

        

        public ActionTakerMythObject(string tag = "default_tag") : base(tag)
        {
            _valid_actions = new List<MythAction>();
            _existing_actions = new List<Tree<MythAction>>();
            buildExistingActionsTree();
        }
    }
}
