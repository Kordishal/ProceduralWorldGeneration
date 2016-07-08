using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Effects
{
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
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
