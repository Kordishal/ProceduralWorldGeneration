using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjectAttributes
{
    class PlaneElement : MythObjectAttribute
    {
        private string _opposite;
        public string Opposite
        {
            get
            {
                return _opposite;
            }
            set
            {
                if (_opposite != value)
                {
                    _opposite = value;
                    base.NotifyPropertyChanged("Opposite");
                }
            }
        }

        public PlaneElement(string tag = "default") : base(tag) { }
    }
}
