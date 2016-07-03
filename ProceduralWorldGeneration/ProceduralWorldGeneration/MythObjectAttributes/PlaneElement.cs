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
        private PlaneElement _opposite;
        public PlaneElement Opposite
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

        private PrimordialForce _primordial_force;
        public PrimordialForce PrimordialForce
        {
            get
            {
                return _primordial_force;
            }
            set
            {
                if (_primordial_force != value)
                {
                    _primordial_force = value;
                    base.NotifyPropertyChanged("PrimordialForce");
                }
            }
        }


        public PlaneElement(string tag = "default") : base(tag) { }
    }
}
