using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    /// <summary>
    /// A class to store the config values for the universe generated.
    /// </summary>
    class ConfigValues : INotifyPropertyChanged
    {

        // The seed for the random number generator. To ensure that each execution comes from the same seed.
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
                    Random = new Random(_random_seed.GetHashCode());
                    NotifyPropertyChanged("RandomSeed");
                }
            }
        }

        static public Random Random { get; set; }
       
        public ConfigValues()
        {
            _random_seed = "Hello World";
            Random = new Random(_random_seed.GetHashCode());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
