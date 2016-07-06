using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProceduralWorldGeneration.Parser.SyntaxTree
{
    [DebuggerDisplay("{TreeRoot}")]
    public class Tree<T> : INotifyPropertyChanged
    {

        public delegate void TreeVisitor(TreeNode<T> current_node);

        private TreeNode<T> _tree_root;
        /// <summary>
        /// Root of the tree
        /// </summary>
        public TreeNode<T> TreeRoot
        {
            get
            {
                return _tree_root;
            }
            set
            {
                if (_tree_root != value)
                {
                    _tree_root = value;
                    this.NotifyPropertyChanged("TreeRoot");
                }
            }
        }

        private TreeNode<T> _current_node;
        /// <summary>
        /// Current node when traversing the tree.
        /// </summary>
        public TreeNode<T> CurrentNode
        {
            get
            {
                return _current_node;
            }
            set
            {
                if (_current_node != value)
                {
                    _current_node = value;
                    this.NotifyPropertyChanged("CurrentNode");
                }
            }
        }

        public Tree(T root_value)
        {
            TreeRoot = new TreeNode<T>(root_value, null);
            CurrentNode = TreeRoot;
        }

        /// <summary>
        /// Breath First Seach of the tree
        /// </summary>
        public void traverseTree(TreeVisitor visitor)
        {
            Queue<TreeNode<T>> search_queue = new Queue<TreeNode<T>>();
            TreeNode<T> current_node = null;
            search_queue.Enqueue(TreeRoot);

            while (search_queue.Count > 0)
            {
                current_node = search_queue.Dequeue();
                visitor(current_node);

                foreach (TreeNode<T> node in current_node.Children)
                {
                    search_queue.Enqueue(node);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return TreeRoot.ToString();
        }
    }
}
