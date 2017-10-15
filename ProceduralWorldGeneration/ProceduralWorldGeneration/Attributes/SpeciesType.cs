using ProceduralWorldGeneration.Utility;
using System;
using System.Collections.Generic;

namespace ProceduralWorldGeneration.Attributes
{
    [Serializable]
    public class SpeciesType : Attribute
    {
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
                    NotifyPropertyChanged("PlaneType");
                }
            }
        }

        public List<string> Attributes { get; set; }
        public string AttributesDisplay { get { return Helpers.ListToString(Attributes); } set { } }
    }
}
