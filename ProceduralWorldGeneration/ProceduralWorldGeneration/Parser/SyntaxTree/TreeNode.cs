using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser.SyntaxTree
{
    public class TreeNode<T> : INotifyPropertyChanged
    {
        /// <summary>
        /// This delegate is applied to every tree node in the tree.
        /// </summary>
        /// <param name="node">Current Node</param>
        public delegate void TreeVisitor(TreeNode<T> node);

        /// <summary>
        /// This delegate is applied to every tree node in the tree.
        /// </summary>
        /// <param name="node">Current Node</param>
        /// <param name="value">Value to be used by the delegate.</param>
        public delegate void TreeVisitorWithValue(TreeNode<T> node, T value);

        /// <summary>
        /// This predicate is used to compare the value of each node with the value.
        /// </summary>
        /// <param name="current_node">Current Node</param>
        /// <param name="value">Value to compare the node value with</param>
        /// <returns></returns>
        public delegate bool SearchPredicate(TreeNode<T> current_node, T value);

        private T _value;
        /// <summary>
        /// The Value of the node.
        /// </summary>
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != null)
                {
                    if (_value.Equals(value))
                    {
                        _value = value;
                        this.NotifyPropertyChanged("Value");
                    }               
                }
                else
                {
                    _value = value;
                    this.NotifyPropertyChanged("Value");
                }
            }
        }

        private int _depth;
        /// <summary>
        /// Depth of this node in the tree.
        /// </summary>
        public int Depth
        {
            get
            {
                return _depth;
            }
            set
            {
                if (_depth != value)
                {
                    _depth = value;
                    this.NotifyPropertyChanged("Depth");
                }
            }
        }

        private TreeNode<T> _parent;
        /// <summary>
        /// Parent of this node.
        /// </summary>
        public TreeNode<T> Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (_parent != value)
                {
                    _parent = value;
                    this.NotifyPropertyChanged("Parent");
                }
            }
        }

        private LinkedList<TreeNode<T>> _children;
        /// <summary>
        /// Children of this node.
        /// </summary>
        public LinkedList<TreeNode<T>> Children
        {
            get
            {
                return _children;
            }
            set
            {
                if (_children != value)
                {
                    _children = value;
                    this.NotifyPropertyChanged("Children");
                }
            }
        }

        public TreeNode(T value, TreeNode<T> parent)
        {
            _parent = parent;
            this.Value = value;
            if (_parent == null)
                _depth = 0;
            else
                _depth = _parent.Depth + 1;

            _children = new LinkedList<TreeNode<T>>();
        }

        /// <summary>
        /// Adds a new last child.
        /// </summary>
        /// <param name="value">Value of this child</param>
        public void AddChild(T value)
        {
            _children.AddLast(new TreeNode<T>(value, this));
        }


        /// <summary>
        /// Gets the last child of this node.
        /// </summary>
        /// <returns>Last Child</returns>
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

        /// <summary>
        /// Gets the first child of this node.
        /// </summary>
        /// <returns>First Child</returns>
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

        /// <summary>
        /// Traverse the tree and call an function on each node. This search is depth first.
        /// </summary>
        /// <param name="visitor">Delegate called on each node</param>
        public void traverseTree(TreeVisitor visitor)
        {
            visitor(this);

            foreach (TreeNode<T> node in _children)
            {
                node.traverseTree(visitor);
            }
        }

        /// <summary>
        /// Depth first search with a value
        /// </summary>
        /// <param name="visitor">Delegate</param>
        /// <param name="value">Value to be used by delegate</param>
        public void traverseTree(TreeVisitorWithValue visitor, T value)
        {
            visitor(this, value);

            foreach (TreeNode<T> node in _children)
            {
                node.traverseTree(visitor, value);
            }
        }

        public TreeNode<T> searchNode(SearchPredicate search_predicate, T value)
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
            return "[" + Value.ToString() + " : " + Depth.ToString() + "]";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
