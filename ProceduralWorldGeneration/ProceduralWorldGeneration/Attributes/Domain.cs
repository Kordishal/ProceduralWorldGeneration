using ProceduralWorldGeneration.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Attributes
{
    [Serializable]
    public class Domain : Attribute
    {
        public List<string> Attributes { get; set; }
        public string AttributesDisplay { get { return Helpers.ListToString(Attributes); } set { } }

        public List<string> OppositeAttributes { get; set; }
        public string OppositeAttributesDisplay { get { return Helpers.ListToString(OppositeAttributes); } set { } }
    }
}
