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
using ProceduralWorldGeneration.MythActions.CreatePlaneActions;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneElementSetters;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.ConnectPlaneActions;
using ProceduralWorldGeneration.MythActions.CreateDeityActions;
using ProceduralWorldGeneration.MythActions.CreateDeityActions.SetDomainActions;

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

        private Plane _plane_construction;
        public Plane PlaneConstruction
        {
            get
            {
                return _plane_construction;
            }
            set
            {
                _plane_construction = value;
            }
        }

        private SapientSpecies _sapient_species_creatio;
        public SapientSpecies SapientSpeciesCreation
        {
            get
            {
                return _sapient_species_creatio;
            }
            set
            {
                _sapient_species_creatio = value;
            }
        }

        private Deity _deity_creation;
        public Deity DeityCreation
        {
            get
            {
                return _deity_creation;
            }
            set
            {
                _deity_creation = value;
            }
        }

        public CreationState CurrentCreationState { get; set; }

        public abstract void takeAction(int current_year);

        public void determineNextGoal()
        {
            TreeNode<CreationTreeNode> action_taker_node = CreationMythState.CreationTree.TreeRoot.searchNode(compareNode, new CreationTreeNode(this));

            if (action_taker_node == null)
            {
                _current_goal = ActionGoal.None;
                _current_action = new Wait();
                CreationMythLogger.updateActionLog(this);
                return;
            }

            foreach (TreeNode<CreationTreeNode> child in action_taker_node.Children)
            {
                if (child.Value.MythObject != null)
                {
                    continue;
                }

                switch (child.Value.Character)
                {
                    case "p":
                        CreationMythLogger.updateActionLog("Start the creation of a plane.");
                        _current_goal = ActionGoal.CreatePlane;
                        child.Value.UnderConstruction = true;
                        child.Value.Creator = this;
                        return;
                    case "d":
                        CreationMythLogger.updateActionLog("Start the creation of a deity.");
                        _current_goal = ActionGoal.CreateDeity;
                        child.Value.UnderConstruction = true;
                        child.Value.Creator = this;
                        return;
                    default:
                        _current_goal = ActionGoal.None;
                        break;
                }

            }

            if (_current_goal == ActionGoal.None)
            {
                foreach (TreeNode<CreationTreeNode> child in action_taker_node.Children)
                {
                    if (_current_goal == ActionGoal.None && child.Value.Character == "p")
                    {
                        foreach (TreeNode<CreationTreeNode> child_of_child in child.Children)
                        {
                            if (child_of_child.Value.MythObject == null)
                            {
                                switch (child_of_child.Value.Character)
                                {
                                    case "w":
                                        CreationMythLogger.updateActionLog("Start the creation of a world.");
                                        _current_goal = ActionGoal.CreateWorld;
                                        child_of_child.Value.UnderConstruction = true;
                                        child.Value.Creator = this;
                                        return;
                                    case "a":
                                        CreationMythLogger.updateActionLog("Start the creation of a sentient species.");
                                        _current_goal = ActionGoal.CreateSapientSpecies;
                                        child.Value.UnderConstruction = true;
                                        child.Value.Creator = this;
                                        return;
                                    default:
                                        _current_goal = ActionGoal.None;
                                        break;
                                }
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

        virtual public void determineNextAction()
        {
            //CreationMythLogger.updateActionLog("NEXT ACTION.");
            //CreationMythLogger.updateActionLog(this);
            
            Tree<MythAction> current_action_tree = null;
            MythAction local_action = null;
            List<TreeNode<MythAction>> next_action_candidates;
            int total_action_weight = 0;

            // if no goal is chosen a new one is determined.
            if (CurrentGoal == ActionGoal.None)
                determineNextGoal();

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
            if (current_action_tree.TreeRoot.Value.checkPrecondition(this))
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
                    if (!action_node.Value.onCooldown() && action_node.Value.checkPrecondition(this))
                    {
                        total_action_weight += action_node.Value.getWeight(this);
                        next_action_candidates.Add(action_node);
                    }
                }

                if (next_action_candidates.Count == 0)
                {
                    CurrentAction = new Wait();
                    return;
                }


                int chance = ConfigValues.RandomGenerator.Next(total_action_weight + 1);
                int prev_weight = 0, current_weight = next_action_candidates[0].Value.getWeight(this);
                foreach (TreeNode<MythAction> action_node in next_action_candidates)
                {
                    // if chance is between the two weights the current action is chosen.
                    if (prev_weight < chance && chance <= current_weight)
                    {
                        local_action = action_node.Value;
                        current_action_tree.CurrentNode = action_node;
                    }

                    prev_weight = current_weight;
                    current_weight += action_node.Value.getWeight(this);
                }                
            }

            _current_action = local_action;

            if  (_current_action == null)
            {
                _current_action = new Wait();
            }
        }

        virtual public void buildExistingActionsTree()
        {
            _existing_actions.Add(new Tree<MythAction>(new CreatePlane()));
            _existing_actions[0].TreeRoot.AddChild(new SetCreator());
            _existing_actions[0].TreeRoot.AddChild(new FormPlane());
            // Types
            _existing_actions[0].TreeRoot.Children.First.Next.Value.AddChild(new SetPlaneType());
            // Sizes
            _existing_actions[0].TreeRoot.Children.First.Next.Value.AddChild(new SetFinitePlaneSize());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.AddChild(new SetInfinitePlaneSize());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.AddChild(new SetNoPlaneSize());
            // Elements
            _existing_actions[0].TreeRoot.Children.First.Next.Value.AddChild(new SetPlaneElement());
            _existing_actions[0].TreeRoot.Children.First.Next.Value.AddChild(new SetNoElement());
            _existing_actions[0].TreeRoot.AddChild(new ConnectPlane());
            _existing_actions[0].TreeRoot.Children.First.Next.Next.Value.AddChild(new SetFirstConnection());
            _existing_actions[0].TreeRoot.Children.First.Next.Next.Value.AddChild(new ConntectEtherealPlane());
            _existing_actions[0].TreeRoot.Children.First.Next.Next.Value.AddChild(new AddConnections());
            _existing_actions[0].TreeRoot.AddChild(new SetName());
            _existing_actions[0].TreeRoot.AddChild(new AddToUniverse());

            _existing_actions.Add(new Tree<MythAction>(new CreateDeity()));
            _existing_actions[1].TreeRoot.AddChild(new SetCreator());
            _existing_actions[1].TreeRoot.AddChild(new SetDomains());
            _existing_actions[1].TreeRoot.Children.First.Next.Value.AddChild(new SetPrimaryDomain());
            _existing_actions[1].TreeRoot.Children.First.Next.Value.AddChild(new AddRandomDomain());
            _existing_actions[1].TreeRoot.AddChild(new SetPersonality());
            _existing_actions[1].TreeRoot.AddChild(new SetPower());
            _existing_actions[1].TreeRoot.AddChild(new SetName());
            _existing_actions[1].TreeRoot.AddChild(new AddToUniverse());
        }

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

        

        public ActionTakerMythObject(string tag = Constants.SpecialTags.DEFAULT_TAG) : base(tag)
        {
            _valid_actions = new List<MythAction>();
            _existing_actions = new List<Tree<MythAction>>();
            CurrentCreationState = new CreationState();
            buildExistingActionsTree();
        }
    }
}
