﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Input.ParserDefinition
{
    class TreeNode<T>
    {
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
            return _children.Last.Value;
        }

        public LinkedList<TreeNode<T>> GetChildren()
        {
            return _children;
        }


    }
}