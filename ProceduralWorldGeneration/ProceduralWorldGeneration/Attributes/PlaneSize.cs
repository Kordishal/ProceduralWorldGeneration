using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Attributes
{
    [Serializable]
    public class PlaneSize : Attribute
    {
        private int _maxNeighbours;
        public int MaxNeighbours
        {
            get
            {
                return _maxNeighbours;
            }
            set
            {
                if (value != _maxNeighbours)
                {
                    _maxNeighbours = value;
                    this.NotifyPropertyChanged("MaxNeighbours");
                }
            }
        }
    }
}
