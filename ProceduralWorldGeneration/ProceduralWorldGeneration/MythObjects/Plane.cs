using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjectAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjects
{
    public class Plane : BaseMythObject
    {
        private PlaneType _plane_type;
        public PlaneType PlaneType
        {
            get
            {
                return _plane_type;
            }
            set
            {
                if (_plane_type != value)
                {
                    _plane_type = value;
                    base.NotifyPropertyChanged("PlaneType");
                }
            }
        }

        private PlaneSize _plane_size;
        public PlaneSize PlaneSize
        {
            get
            {
                return _plane_size;
            }
            set
            {
                if (_plane_size != value)
                {
                    _plane_size = value;
                    base.NotifyPropertyChanged("PlaneSize");
                }
            }
        }

        private PlaneElement _plane_element;
        public PlaneElement PlaneElement
        {
            get
            {
                return _plane_element;
            }
            set
            {
                if (_plane_element != value)
                {
                    _plane_element = value;
                    base.NotifyPropertyChanged("PlaneElement");
                }
            }
        }

        private BaseMythObject _creator;
        public BaseMythObject Creator
        {
            get
            {
                return _creator;
            }
            set
            {
                if (_creator != value)
                {
                    _creator = value;
                    base.NotifyPropertyChanged("Creator");
                }
            }
        }

        private List<Plane> _neighbour_planes;
        public List<Plane> NeighbourPlanes
        {
            get
            {
                return _neighbour_planes;
            }
            set
            {
                if (_neighbour_planes != value)
                {
                    _neighbour_planes = value;
                    base.NotifyPropertyChanged("NeighbourPlanes");
                }
            }
        }

        public bool maxConnectionsReached()
        {
            if (_plane_size.MaxNeighbourPlanes == -1)
                return false;
            else
                return _neighbour_planes.Count == _plane_size.MaxNeighbourPlanes;
        }

        public bool isNotConnectedTo(Plane plane)
        {
            foreach (Plane p in _neighbour_planes)
                if (p.Equals(plane))
                    return true;

            return false;
        }

        public void connectPlane(Plane connect_plane)
        {
            _neighbour_planes.Add(connect_plane);
            connect_plane.NeighbourPlanes.Add(this);           
        }

        public Plane() : base()
        {
            _neighbour_planes = new List<Plane>();
        }

    }
}
