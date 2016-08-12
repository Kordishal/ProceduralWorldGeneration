using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjectAttributes
{
    public class CivilisationEthos : MythObjectAttribute
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
                    base.NotifyPropertyChanged("Opposite");
                }
            }
        }

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    base.NotifyPropertyChanged("Value");
                }
            }
        }
    }
}
