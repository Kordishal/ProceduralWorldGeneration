using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Utility;

namespace ProceduralWorldGeneration.MythActions.CreateSapientSpeciesActions
{
    class SetPlaneAndWorld : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentGoal == ActionGoal.CreateSapientSpecies)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            TreeNode<CreationTreeNode> species_node = CreationMythState.CreationTree.TreeRoot.searchNode(searchPlaneNode, new CreationTreeNode(taker));

            if (species_node.Parent.Value.Character == "p")
                taker.CreatedSapientSpecies.NativePlane = (Plane)species_node.Parent.Value.MythObject;

        }


        private bool searchPlaneNode(TreeNode<CreationTreeNode> current_node, CreationTreeNode value)
        {
            if (current_node.Value.Character == "a")
            {
                if (current_node.Parent.Parent.Value.MythObject == value.MythObject)
                {
                    if (current_node.Parent.Value.Character == "p")
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;

        }
    }
}
