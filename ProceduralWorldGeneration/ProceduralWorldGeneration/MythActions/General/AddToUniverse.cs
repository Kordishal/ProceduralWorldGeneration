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

namespace ProceduralWorldGeneration.MythActions.General
{
    class AddToUniverse : MythAction
    {

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.CurrentGoal == ActionGoal.CreatePlane)
            {
                CreationMythState.MythObjects.Add(taker.CreatedPlane);
                CreationMythState.Planes.Add(taker.CreatedPlane);
                CreationMythState.CreationTree.TreeRoot.traverseTree(addPlaneToCreationTree, new CreationTreeNode(taker));
            }
            else if (taker.CurrentGoal == ActionGoal.CreateDeity)
            {
                CreationMythState.ActionableMythObjects.Enqueue(taker.CreadedDeity);
                CreationMythState.MythObjects.Add(taker.CreadedDeity);
                CreationMythState.Deities.Add(taker.CreadedDeity);
                CreationMythState.CreationTree.TreeRoot.traverseTree(addDeityToCreationTree, new CreationTreeNode(taker));
            }
                     
            taker.CurrentGoal = ActionGoal.None;
            CreationMythLogger.updateActionLog(taker, true);
        }

        private void addPlaneToCreationTree(TreeNode<CreationTreeNode> current_node, CreationTreeNode node)
        {
            if (current_node.Value.UnderConstruction)
            {
                if (current_node.Value.Creator == node.MythObject)
                {
                    PrimordialForce taker = (PrimordialForce)node.MythObject;
                    current_node.Value.MythObject = taker.CreatedPlane;
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
                    current_node.Value.MythObject = taker.CreadedDeity;
                    current_node.Value.UnderConstruction = false;
                }
            }
        }
    }
}
