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
    class AddPlaneToUniverse : MythAction
    {

        public AddPlaneToUniverse() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            if (taker.GetType() == typeof(PrimordialForce))
            {
                PrimordialForce _taker = (PrimordialForce)taker;
                if (_taker.PlaneConstructionState.hasName && !_taker.PlaneConstructionState.isAddedToUniverse)
                    return true;
                else
                    return false;
            }
            else
                return false;
   
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            state.MythObjects.Add(_taker.PlaneConstruction);
            state.Planes.Add(_taker.PlaneConstruction);
            state.CreationTree.TreeRoot.traverseTree(addPlaneToCreationTree, new CreationTreeNode(taker));
            _taker.PlaneConstructionState = new CreatePlaneCreationState();
            _taker.PlaneConstruction = null;
            CreationMythLogger.updateActionLog(_taker, true);
            _taker.CurrentGoal = ActionGoal.None;
        }

        private void addPlaneToCreationTree(TreeNode<CreationTreeNode> current_node, CreationTreeNode node)
        {
            if (current_node.Value.UnderConstruction)
            {
                if (current_node.Value.Creator == node.MythObject)
                {
                    PrimordialForce _taker = (PrimordialForce)node.MythObject;
                    current_node.Value.MythObject = _taker.PlaneConstruction;
                    current_node.Value.UnderConstruction = false;
                }
            }
        }
    }
}
