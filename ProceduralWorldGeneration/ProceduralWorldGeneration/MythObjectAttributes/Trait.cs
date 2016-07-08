using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjectAttributes
{
    public class Trait : MythObjectAttribute
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
                    base.NotifyPropertyChanged("Category");
                }
            }
        }

        private List<string> _trait_tags;
        public List<string> TraitTags
        {
            get
            {
                return _trait_tags;
            }
            set
            {
                if (_trait_tags != value)
                {
                    _trait_tags = value;
                    base.NotifyPropertyChanged("TraitTags");
                }
            }
        }



        public Trait(string tag = "default_tag") : base(tag)
        {
            _trait_tags = new List<string>();
        }
    }
}
