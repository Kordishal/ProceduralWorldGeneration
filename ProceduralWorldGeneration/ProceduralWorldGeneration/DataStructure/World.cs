using ProceduralWorldGeneration.Elements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.DataStructure
{
    class World : INotifyPropertyChanged
    {
        private Element _world_element;
        public Element WorldElements
        {
            get
            {
                return _world_element;
            }
            set
            {
                if (_world_element != value)
                {
                    _world_element = value;
                    this.NotifyPropertyChanged("WorldElement");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
