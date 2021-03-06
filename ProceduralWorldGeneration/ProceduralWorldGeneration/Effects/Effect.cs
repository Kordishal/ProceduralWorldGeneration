﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Effects
{
    /// <summary>
    /// ABSTRACT CLASS
    /// An Effect is an object with a tag, name and spawn weight. 
    /// Needs to be implemented into specific effects for myth objects.
    /// </summary>
    public abstract class Effect : INotifyPropertyChanged
    {

        private string _tag;
        public string Tag
        {
            get
            {
                return _tag;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        private int _spawn_weight;
        public int SpawnWeight
        {
            get
            {
                return _spawn_weight;
            }
            set
            {
                if (value != _spawn_weight)
                {
                    _spawn_weight = value;
                    this.NotifyPropertyChanged("SpawnWeight");
                }
            }
        }

        public Effect(string tag = "default")
        {
            _tag = tag;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
