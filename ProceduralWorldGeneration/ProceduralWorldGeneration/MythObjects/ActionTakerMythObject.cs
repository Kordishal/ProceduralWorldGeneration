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
using ProceduralWorldGeneration.Output;

namespace ProceduralWorldGeneration.MythObjects
{
    public abstract class ActionTakerMythObject : BaseMythObject, IActionTaker
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
            TreeNode<CreationTreeNode> action_taker_node = creation_myth.CreationTree.TreeRoot.searchNode(compareNode, new CreationTreeNode(this));

            if (action_taker_node == null)
            {
                _current_goal = ActionGoal.None;
                _current_action = new Wait();
                CreationMythLogger.updateActionLog(this);
                return;
            }

            foreach (TreeNode<CreationTreeNode> child in action_taker_node.Children)
            {
                if (child.Value.MythObject == null)
                {
                    switch (child.Value.Character)
                    {
                        case "p":
                            _current_goal = ActionGoal.CreatePlane;
                            child.Value.UnderConstruction = true;
                            child.Value.Creator = this;
                            break;
                        case "d":
                            _current_goal = ActionGoal.CreateDeity;
                            child.Value.UnderConstruction = true;
                            child.Value.Creator = this;
                            break;
                        case "a":
                            _current_goal = ActionGoal.CreateSapientSpecies;
                            child.Value.UnderConstruction = true;
                            child.Value.Creator = this;
                            break;
                        default:
                            _current_goal = ActionGoal.None;
                            break;
                    }
                }

                if (_current_goal == ActionGoal.None && child.Value.Character == "p")
                {
                    foreach (TreeNode<CreationTreeNode> child_of_child in child.Children)
                    {
                        if (child_of_child.Value.MythObject == null)
                        {
                            switch (child_of_child.Value.Character)
                            {
                                case "w":
                                    _current_goal = ActionGoal.CreateWorld;
                                    child_of_child.Value.UnderConstruction = true;
                                    child.Value.Creator = this;
                                    break;
                                default:
                                    _current_goal = ActionGoal.None;
                                    break;
                            }
                        }
                    }
                }
            }

            
        }

        private bool compareNode(TreeNode<CreationTreeNode> current_node, CreationTreeNode tree_node_value)
        {
            if (current_node.Value.MythObject == tree_node_value.MythObject)
            {
                return true;
            }
            else
            {
                return false;
            }
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

            // if after choosing a new goal it still has no action it simply waits for better times.
            if (CurrentGoal == ActionGoal.None)
            {
                CurrentAction = new Wait();
                return;
            }

            // Set the current action tree according to the goal to be achieved.
            foreach (Tree<MythAction> action_tree in _existing_actions)
                if (action_tree.TreeRoot.Value.ReachableGoal == CurrentGoal)
                    current_action_tree = action_tree;

            if (current_action_tree == null)
            {
                CurrentAction = new Wait();
                return;
            }

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
