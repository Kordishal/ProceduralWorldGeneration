using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    class WorldGenerationConfig : INotifyPropertyChanged
    {

        private string _random_seed;
        public string RandomSeed
        {
            get
            {
                return _random_seed;
            }
            set
            {
                if (value != _random_seed)
                {
                    _random_seed = value;
                    NotifyPropertyChanged("RandomSeed");
                }
            }
        }

        public WorldGenerationConfig()
        {
            _random_seed = "Hello World";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
