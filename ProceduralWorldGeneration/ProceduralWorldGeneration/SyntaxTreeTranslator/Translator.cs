using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Parser;
using ProceduralWorldGeneration.Parser.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.SyntaxTreeTranslator
{
    class Translator
    {
        private MythObjectData data { get; set; }
        private Tree<Expression> SyntaxTree { get; set; }      

        public Translator(Tree<Expression> syntax_tree)
        {
            SyntaxTree = syntax_tree;
        }

        public MythObjectData translate()
        {
            data = new MythObjectData();

            SyntaxTree.TreeRoot.traverseTree(translator);

            return data;
        }


        private void translator(TreeNode<Expression> current_node)
        {
            if (current_node.Value.ExpressionType == ExpressionTypes.Root)
            {
                return;
            }

            TreeNode<Expression> parent_node = current_node.GetParent();

            if (current_node.Value.ExpressionType == ExpressionTypes.Assignment)
            {


            }


        }
    }
}
