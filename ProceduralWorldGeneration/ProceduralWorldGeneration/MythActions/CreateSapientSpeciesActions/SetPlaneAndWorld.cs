using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Parser.SyntaxTree;
using ProceduralWorldGeneration.Generator;

namespace ProceduralWorldGeneration.MythActions.CreateSapientSpeciesActions
{
    class SetPlaneAndWorld : PrimitivMythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.isCreatingSapientSpecies && !taker.CurrentCreationState.hasPlaneAndWorld)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            TreeNode<CreationTreeNode> plane_node = CreationMythState.CreationTree.TreeRoot.searchNode(searchPlaneNode, new CreationTreeNode("p"));


            taker.CurrentCreationState.hasPlaneAndWorld = true;
        }


        private bool searchPlaneNode(TreeNode<CreationTreeNode> current_node, CreationTreeNode value)
        {
            return true;
        }
    }
}
