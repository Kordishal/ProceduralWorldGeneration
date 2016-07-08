using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjectAttributes
{
    public class SpeciesType : MythObjectAttribute
    {

        private string _preferred_plane_type;
        public string preferredPlaneType
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

        public SpeciesType(string tag = "default") : base(tag)
        {
        }
    }
}
