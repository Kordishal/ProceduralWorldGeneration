using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Attributes
{
    [Serializable]
    public class PlaneElement : Attribute
    {
        private string _opposite { get; set; }
        public string Opposite
        {
            get { return _opposite; }
            set
            {
                if (value != _opposite)
                {
                    _opposite = value;
                    NotifyPropertyChanged("Opposite");
                }
            }
        }

    }
}
