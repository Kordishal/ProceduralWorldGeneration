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
        private Element _base_element;
        public Element BaseElement
        {
            get
            {
                return _base_element;
            }
            set
            {
                if (_base_element != value)
                {
                    _base_element = value;
                    this.NotifyPropertyChanged("WorldElement");
                }
            }
        }

        private ObservableCollection<Element> _element_collection;
        public ObservableCollection<Element> ElementCollection
        {
            get
            {
                return _element_collection;
            }
            set
            {
                if (_element_collection != value)
                {
                    _element_collection = value;
                    this.NotifyPropertyChanged("ElementCollection");
                }
            }
        }


        public World()
        {
            _element_collection = new ObservableCollection<Element>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
