using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjectAttributes
{
    class SpeciesType : MythObjectAttribute
    {

        private bool _preferred_plane_type;
        public bool preferredPlaneType
        {
            get
            {
                return _preferred_plane_type;
            }
            set
            {
                if (_preferred_plane_type != value)
                {
                    _preferred_plane_type = value;
                    base.NotifyPropertyChanged("preferredPlaneType");
                }
            }
        }
    }
}
