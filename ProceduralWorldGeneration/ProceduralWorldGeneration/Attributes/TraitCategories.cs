using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Attributes
{
    [Serializable]
    public class TraitCategories : Attribute
    {

        private bool _always;
        public bool Always
        {
            get
            {
                return _always;
            }
            set
            {
                if (_always != value)
                {
                    _always = value;
                    NotifyPropertyChanged("Always");
                }
            }
        }

        private bool _unique;
        public bool Unique
        {
            get
            {
                return _unique;
            }
            set
            {
                if (_unique != value)
                {
                    _unique = value;
                    NotifyPropertyChanged("Unique");
                }
            }
        }
    }
}
