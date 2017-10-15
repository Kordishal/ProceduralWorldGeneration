using ProceduralWorldGeneration.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Attributes
{
    [Serializable]
    public class SpeciesTrait : Attribute
    {
        private string _category;
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    NotifyPropertyChanged("Category");
                }
            }
        }

        public List<string> Attributes { get; set; }
        public string AttributesDisplay { get { return Helpers.ListToString(Attributes); } set { } }

        public List<string> OppositeAttributes { get; set; }
        public string OppositeAttributesDisplay { get { return Helpers.ListToString(OppositeAttributes); } set { } }

        public List<string> ExcludedTags { get; set; }
        public string ExcludedTagsDisplay { get { return Helpers.ListToString(Attributes); } set { } }
    }
}
