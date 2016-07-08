using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjectAttributes
{
    public class Ethos : MythObjectAttribute
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

        private int[] _range;
        public int[] Range
        {
            get
            {
                return _range;
            }
            set
            {
                if (_range != value)
                {
                    _range = value;
                    base.NotifyPropertyChanged("Range");
                }
            }
        }
    }
}
