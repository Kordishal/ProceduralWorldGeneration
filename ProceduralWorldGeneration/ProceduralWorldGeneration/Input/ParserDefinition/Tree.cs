using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Input.ParserDefinition
{
    class Tree<T> : TreeNode<T>
    {


        public Tree(T root_value) : base(root_value, null)
        {

        }

    }
}
