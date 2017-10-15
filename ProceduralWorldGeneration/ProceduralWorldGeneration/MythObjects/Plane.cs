using ProceduralWorldGeneration.Attributes;
using System.Collections.Generic;

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
                    NotifyPropertyChanged("PlaneType");
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
                    NotifyPropertyChanged("PlaneSize");
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
                    NotifyPropertyChanged("PlaneElement");
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
                    NotifyPropertyChanged("NeighbourPlanes");
                }
            }
        }

        public bool MaxConnectionsReached()
        {
            if (_plane_size.MaxNeighbours == -1)
                return false;
            else
                return _neighbour_planes.Count == _plane_size.MaxNeighbours;
        }

        public bool IsNotConnectedTo(Plane plane)
        {
            foreach (Plane p in _neighbour_planes)
                if (p.Identifier == plane.Identifier)
                    return false;

            return true;
        }

        public void connectPlane(Plane connect_plane)
        {
            _neighbour_planes.Add(connect_plane);
            connect_plane.NeighbourPlanes.Add(this);  
        }

        public Plane(string tag = Constants.SpecialTags.DEFAULT_TAG) : base(tag)
        {
            _neighbour_planes = new List<Plane>();
        }

    }
}
