﻿using System.Collections.Generic;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythActions;
using ProceduralWorldGeneration.Output;
using ProceduralWorldGeneration.MythActions.General;
using ProceduralWorldGeneration.Utility;

namespace ProceduralWorldGeneration.MythObjects
{
    /// <summary>
    /// The base class for a myth object which can act during basic world creation.
    /// </summary>
    public abstract class ActionTakerMythObject : BaseMythObject, IActionTaker
    {
        private MythActionStateMachine<MythAction> _action_fsm { get; set; }

        protected abstract void setStateTransitions();

        protected void AddTransition(MythAction initial_state, MythAction end_state)
        {
            _action_fsm.AddTransition(initial_state, end_state, end_state.Effect);
        }

        public MythAction CurrentAction
        {
            get
            {
                return _action_fsm.CurrentState;
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

        private Plane _created_plane;
        public Plane CreatedPlane
        {
            get
            {
                return _created_plane;
            }
            set
            {
                _created_plane = value;
            }
        }

        private SapientSpecies _created_sapient_species;
        public SapientSpecies CreatedSapientSpecies
        {
            get
            {
                return _created_sapient_species;
            }
            set
            {
                _created_sapient_species = value;
            }
        }

        private Deity _created_deity;
        public Deity CreadedDeity
        {
            get
            {
                return _created_deity;
            }
            set
            {
                _created_deity = value;
            }
        }

        private Civilisation _created_civilisation;
        public Civilisation CreatedCivilisation
        {
            get { return _created_civilisation; }
            set { _created_civilisation = value; }
        }

        public abstract void takeAction(int current_year);

        public void determineNextGoal()
        {
            TreeNode<CreationTreeNode> action_taker_node = CreationMythState.CreationTree.TreeRoot.searchNode(compareNode, new CreationTreeNode(this));

            if (action_taker_node == null)
            {
                _current_goal = ActionGoal.None;
                _action_fsm.Advance(new Wait());
                CreationMythLogger.UpdateActionLog(this);
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
                        CreationMythLogger.UpdateActionLog("Start the creation of a plane.");
                        _current_goal = ActionGoal.CreatePlane;
                        child.Value.UnderConstruction = true;
                        child.Value.Creator = this;
                        return;
                    case "d":
                        CreationMythLogger.UpdateActionLog("Start the creation of a deity.");
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
                                        CreationMythLogger.UpdateActionLog("Start the creation of a world.");
                                        _current_goal = ActionGoal.CreateWorld;
                                        child_of_child.Value.UnderConstruction = true;
                                        child.Value.Creator = this;
                                        return;
                                    case "a":
                                        CreationMythLogger.UpdateActionLog("Start the creation of a sapient species.");
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
            List<MythAction> next_actions = new List<MythAction>();
            MythAction current_action = _action_fsm.CurrentState;
            int total_weight = 0;
            foreach (MythAction action in _action_fsm.getPossibleStates())
            {
                if (action.checkPrecondition(this))
                {
                    next_actions.Add(action);
                    total_weight += action.getWeight(this);
                }
            }


            int random = ConfigValues.Random.Next(total_weight);
            int prev_weight = 0, current_weight;
            foreach (MythAction action in next_actions)
            {
                current_weight = action.getWeight(this);
                if (prev_weight <= random && random < current_weight)
                {
                    _action_fsm.Advance(action, this);
                    return;
                }

                prev_weight = current_weight;
            }
        }
        

        public ActionTakerMythObject(string tag = Constants.SpecialTags.DEFAULT_TAG) : base(tag)
        {
            _action_fsm = new MythActionStateMachine<MythAction>();
            _action_fsm.Initialise(new InitialActionState());
            setStateTransitions();
        }
    }
}
