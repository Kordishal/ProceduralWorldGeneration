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

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasName && !taker.CurrentCreationState.isAddedToUniverse)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.isCreatingPlane)
            {
                CreationMythState.MythObjects.Add(taker.PlaneConstruction);
                CreationMythState.Planes.Add(taker.PlaneConstruction);
                CreationMythState.CreationTree.TreeRoot.traverseTree(addPlaneToCreationTree, new CreationTreeNode(taker));
            }
            else if (taker.CurrentCreationState.isCreatingDeity)
            {
                CreationMythState.ActionableMythObjects.Enqueue(taker.DeityCreation);
                CreationMythState.MythObjects.Add(taker.DeityCreation);
                CreationMythState.Deities.Add(taker.DeityCreation);
                CreationMythState.CreationTree.TreeRoot.traverseTree(addDeityToCreationTree, new CreationTreeNode(taker));
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
