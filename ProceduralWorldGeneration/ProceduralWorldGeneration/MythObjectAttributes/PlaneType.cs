using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjectAttributes
{
    class PlaneType : MythObjectAttribute
    {

        private bool _has_dominant_element;
        public bool hasDominantElement
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
                    base.NotifyPropertyChanged("hasDominantElement");
                }
            }
        }

        private PlaneType _is_attached_to;
        public PlaneType isAttachedTo
        {
            get
            {
                return _is_attached_to;
            }
            set
            {
                if (_is_attached_to != value)
                {
                    _is_attached_to = value;
                    base.NotifyPropertyChanged("isAttachedTo");
                }
            }
        }

        public PlaneType(string tag = "default") : base(tag)
        {

        }
    }
}
