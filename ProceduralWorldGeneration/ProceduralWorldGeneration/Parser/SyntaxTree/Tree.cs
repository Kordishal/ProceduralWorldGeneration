using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser.SyntaxTree
{
    class Tree<T> : TreeNode<T>, INotifyPropertyChanged
    {


        public TreeNode<T> TreeRoot { get; set; }

        public TreeNode<T> CurrentNode { get; set; }


        public Tree(T root_value) : base(root_value, null)
        {
            TreeRoot = new TreeNode<T>(root_value, null);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
