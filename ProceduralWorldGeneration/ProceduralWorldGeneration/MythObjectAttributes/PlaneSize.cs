using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjectAttributes
{
    public class PlaneSize : MythObjectAttribute
    {

        private int _max_neighbour_planes;
        public int MaxNeighbourPlanes
        {
            get
            {
                return _max_neighbour_planes;
            }
            set
            {
                if (value != _max_neighbour_planes)
                {
                    _max_neighbour_planes = value;
                    this.NotifyPropertyChanged("MaxNeighbourPlanes");
                }
            }
        }

        public PlaneSize(string tag = "default") : base(tag)
        {

        }
    }
}
