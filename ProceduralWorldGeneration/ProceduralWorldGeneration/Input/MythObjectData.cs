using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Input
{
    class MythObjectData
    {

        public List<BaseMythObject> DefinedMythObjects = new List<BaseMythObject>();

        // PRIMORDIAL FORCES
        public List<PrimordialForce> PrimordialForces = new List<PrimordialForce>();

        // DEITIES
        public List<string> Domains = new List<string>();

        // PLANES
        public List<Plane> DefinedPlanes = new List<Plane>();

        public List<string> PlaneTypes = new List<string>();
        public List<string> PlaneSizes = new List<string>();
        public List<string> PlaneElements = new List<string>();


        public MythObjectData()
        {

        }

    }
}
