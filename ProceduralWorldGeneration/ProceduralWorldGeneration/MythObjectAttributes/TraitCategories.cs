using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjectAttributes
{
    public class TraitCategory : MythObjectAttribute
    {
        private bool is_forced;
        public bool isForced
        {
            get
            {
                return is_forced;
            }
            set
            {
                if (is_forced != value)
                {
                    is_forced = value;
                    base.NotifyPropertyChanged("isForced");
                }
            }
        }

        private bool is_unique;
        public bool isUnique
        {
            get
            {
                return is_unique;
            }
            set
            {
                if (is_unique != value)
                {
                    is_unique = value;
                    base.NotifyPropertyChanged("isUnique");
                }
            }
        }


        public TraitCategory(string tag = "default") : base(tag)
        {

        }
    }
}
