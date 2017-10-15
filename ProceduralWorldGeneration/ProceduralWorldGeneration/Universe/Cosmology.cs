using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Universe
{
    class Cosmology
    {
        public List<PrimordialForce> PrimordialForces { get; set; }

        public List<Plane> Planes { get; set; }

        public List<Deity> Deities { get; set; }


        public Cosmology()
        {
            PrimordialForces = new List<PrimordialForce>();
            Planes = new List<Plane>();
            Deities = new List<Deity>();
        }
    }
}
