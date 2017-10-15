using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Attributes
{

    public class Attribute : INotifyPropertyChanged
    {
        private string _name { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private string _tag { get; set; }
        public string Tag
        {
            get { return _tag; }
            set
            {
                if (value != _tag)
                {
                    _tag = value;
                    NotifyPropertyChanged("Tag");
                }
            }
        }

        private string _spawn_weight { get; set; }
        public string SpawnWeight
        {
            get { return _spawn_weight; }
            set
            {
                if (value != _spawn_weight)
                {
                    _spawn_weight = value;
                    NotifyPropertyChanged("SpawnWeight");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
