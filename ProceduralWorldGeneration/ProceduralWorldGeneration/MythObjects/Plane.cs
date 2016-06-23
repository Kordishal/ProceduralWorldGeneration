using ProceduralWorldGeneration.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjects
{
    class Plane : BaseMythObject
    {

        public static string TYPE = "PLANE";


        private string _plane_type;
        public string PlaneType
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

        private string _plane_size;
        public string PlaneSize
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
                switch (_plane_size)
                {
                    case "infinite":
                        _max_neighbour_planes = 10000;
                        break;
                    case "large":
                        _max_neighbour_planes = 16;
                        break;
                    case "medium":
                        _max_neighbour_planes = 8;
                        break;
                    case "small":
                        _max_neighbour_planes = 4;
                        break;
                    case "pocket":
                        _max_neighbour_planes = 1;
                        break;
                }
            }
        }

        private bool _has_dominant_element = false;
        public bool hasDominantElement
        {
            get
            {
                return _has_dominant_element;
            }
        }

        private string _plane_element;
        public string PlaneElement
        {
            get
            {
                return _plane_element;
            }
            set
            {
                if (_plane_element != value)
                {
                    _has_dominant_element = true;
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

        private int _max_neighbour_planes;
        public int MaxNeighbourPlanes
        {
            get
            {
                return _max_neighbour_planes;
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

        // each plane connects always at least with one other plane
        int _base_connection_chance = 100;

        public void connectPlane(List<Plane> existing_planes)
        {
            int current_connection_chance = _base_connection_chance;

            foreach (Plane p in existing_planes)
            {
                if (_neighbour_planes.Count >= _max_neighbour_planes)
                {
                    return;
                }
                // ethereal planes are only connected to a single material world.
                else if (this.PlaneType == "ethereal")
                {
                    if (p.PlaneType == "material" && p._max_neighbour_planes > p._neighbour_planes.Count)
                    {
                        NeighbourPlanes.Add(p);
                        p.NeighbourPlanes.Add(this);
                        return;
                    }
                }
                // the chance to add an additional plane && whether the current plane can actually accept a new neighbour
                else if (current_connection_chance >= ConfigValues.RandomGenerator.Next(_base_connection_chance) && p._max_neighbour_planes < p._neighbour_planes.Count)
                {
                    NeighbourPlanes.Add(p);
                    p.NeighbourPlanes.Add(this);
                    current_connection_chance = current_connection_chance / 2;
                }
            }
        }

        public Plane() : base()
        {
            base.Type = TYPE;
            _neighbour_planes = new List<Plane>();
        }

    }
}
