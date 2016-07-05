using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser.SyntaxTree
{
    class Tree<T> : INotifyPropertyChanged
    {

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
