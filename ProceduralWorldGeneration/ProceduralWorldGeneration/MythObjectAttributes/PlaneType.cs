using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjectAttributes
{
    public class PlaneType : MythObjectAttribute
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

        private bool _is_infinite_only;
        public bool isInfiniteOnly
        {
            get
            {
                return _is_infinite_only;
            }
            set
            {
                if (_is_infinite_only != value)
                {
                    _is_infinite_only = value;
                    base.NotifyPropertyChanged("isInfiniteOnly");
                }
            }
        }

        private string _is_attached_to;
        public string isAttachedTo
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
