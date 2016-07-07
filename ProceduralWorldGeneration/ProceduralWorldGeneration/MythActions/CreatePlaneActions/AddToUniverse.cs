using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Parser.SyntaxTree;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Output;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class AddToUniverse : MythAction
    {

        public AddToUniverse() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasName && !taker.CurrentCreationState.isAddedToUniverse)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.isCreatingPlane)
            {
                state.MythObjects.Add(taker.PlaneConstruction);
                state.Planes.Add(taker.PlaneConstruction);
                state.CreationTree.TreeRoot.traverseTree(addPlaneToCreationTree, new CreationTreeNode(taker));
            }
            else if (taker.CurrentCreationState.isCreatingDeity)
            {
                state.ActionableMythObjects.Enqueue(taker.DeityCreation);
                state.MythObjects.Add(taker.DeityCreation);
                state.Deities.Add(taker.DeityCreation);
                state.CreationTree.TreeRoot.traverseTree(addDeityToCreationTree, new CreationTreeNode(taker));
            }
            
            
            
            
            taker.CurrentGoal = ActionGoal.None;
            taker.CurrentCreationState = new CreationState();
            CreationMythLogger.updateActionLog(taker, true);
        }

        private void addPlaneToCreationTree(TreeNode<CreationTreeNode> current_node, CreationTreeNode node)
        {
            if (current_node.Value.UnderConstruction)
            {
                if (current_node.Value.Creator == node.MythObject)
                {
                    PrimordialForce taker = (PrimordialForce)node.MythObject;
                    current_node.Value.MythObject = taker.PlaneConstruction;
                    current_node.Value.UnderConstruction = false;
                }
            }
        }

        private void addDeityToCreationTree(TreeNode<CreationTreeNode> current_node, CreationTreeNode node)
        {
            if (current_node.Value.UnderConstruction)
            {
                if (current_node.Value.Creator == node.MythObject)
                {
                    PrimordialForce taker = (PrimordialForce)node.MythObject;
                    current_node.Value.MythObject = taker.DeityCreation;
                    current_node.Value.UnderConstruction = false;
                }
            }
        }
    }
}
