using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Attributes
{
    [Serializable]
    public class PlaneType : Attribute
    {
        private bool _has_dominant_element;
        public bool HasDominantElement
        {
            get
            {
                return _has_dominant_element;
            }
            set
            {
                if (_has_dominant_element != value)
                {
                    _has_dominant_element = value;
                    NotifyPropertyChanged("HasDominantElement");
                }
            }
        }

        private string _is_integrated;
        public string IsIntegrated
        {
            get
            {
                return _is_integrated;
            }
            set
            {
                if (_is_integrated != value)
                {
                    _is_integrated = value;
                    NotifyPropertyChanged("IsIntegrated");
                }
            }
        }

    }
}
