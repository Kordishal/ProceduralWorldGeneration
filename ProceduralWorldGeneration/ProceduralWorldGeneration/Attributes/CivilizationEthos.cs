using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Attributes
{
    public class CivilizationEthos : Attribute
    {
        private string _opposite;
        public string Opposite
        {
            get
            {
                return _opposite;
            }
            set
            {
                if (_opposite != value)
                {
                    _opposite = value;
                    NotifyPropertyChanged("Opposite");
                }
            }
        }

        private int _strength;
        public int Strength
        {
            get
            {
                return _strength;
            }
            set
            {
                if (_strength != value)
                {
                    _strength = value;
                    NotifyPropertyChanged("Value");
                }
            }
        }
    }
}
