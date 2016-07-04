using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser.SyntaxTree
{
    class TreeNode<T>
    {
        public delegate void TreeVisitor(TreeNode<T> node);
        public delegate bool SearchPredicate(TreeNode<T> current_node, string value);

        public T Value { get; set; }
        public int Depth { get; set; }

        private TreeNode<T> _parent;
        private LinkedList<TreeNode<T>> _children;

        public TreeNode(T value, TreeNode<T> parent)
        {
            _parent = parent;
            this.Value = value;
            if (_parent == null)
                Depth = 0;
            else
                Depth = _parent.Depth + 1;

            _children = new LinkedList<TreeNode<T>>();
        }


        public TreeNode<T> GetParent()
        {
            return _parent;
        }

        public void AddChild(T value)
        {
            _children.AddLast(new TreeNode<T>(value, this));
        }

        public TreeNode<T> GetLastChild()
        {
            if (_children.Last != null)
            {
                return _children.Last.Value;
            }
            else
            {
                return null;
            }
        }

        public TreeNode<T> GetFirstChild()
        {
            if (_children.First != null)
            {
                return _children.First.Value;
            }
            else
            {
                return null;
            }
            
        }

        public LinkedList<TreeNode<T>> GetChildren()
        {
            return _children;
        }

        public void traverseTree(TreeVisitor visitor)
        {
            visitor(this);

            foreach (TreeNode<T> node in _children)
            {
                node.traverseTree(visitor);
            }
        }

        public TreeNode<T> searchNode(SearchPredicate search_predicate, string value)
        {
            if (search_predicate(this, value))
            {
                return this;
            }
            else
            {

                TreeNode<T> temp = null;
                foreach (TreeNode<T> node in _children)
                {
                    temp = node.searchNode(search_predicate, value);                   
                }

                if (temp != null)
                {
                    return temp;
                }
                else
                {
                    return null;
                }
            }
            

        }


        public override string ToString()
        {
            return Value.ToString() + " : " + Depth.ToString();
        }

    }
}
