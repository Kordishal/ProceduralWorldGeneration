using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    class ConfigValues : INotifyPropertyChanged
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
                    RandomGenerator = new Random(_random_seed.GetHashCode());
                    NotifyPropertyChanged("RandomSeed");
                }
            }
        }

        static public Random RandomGenerator { get; set; }
        

        public ConfigValues()
        {
            _random_seed = "Hello World";
            RandomGenerator = new Random(_random_seed.GetHashCode());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
