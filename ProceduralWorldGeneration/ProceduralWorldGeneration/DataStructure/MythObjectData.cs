using ProceduralWorldGeneration.MythObjectAttributes;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.DataStructure
{
    class MythObjectData
    {

        public List<BaseMythObject> DefinedMythObjects = new List<BaseMythObject>();
        public List<MythObjectAttribute> MythObjectAttributes = new List<MythObjectAttribute>();

        // PRIMORDIAL FORCES
        public List<PrimordialForce> PrimordialForces = new List<PrimordialForce>();

        // DEITIES
        public List<string> Domains = new List<string>();

        // PLANES
        public List<Plane> DefinedPlanes = new List<Plane>();

        public List<PlaneType> PlaneTypes = new List<PlaneType>();
        public List<PlaneSize> PlaneSizes = new List<PlaneSize>();
        public List<PlaneElement> PlaneElements = new List<PlaneElement>();


        public MythObjectData()
        {

        }

        public MythObjectAttribute searchAttribute(string tag)
        {
            foreach (MythObjectAttribute mythobjattr in MythObjectAttributes)
            {
                if (mythobjattr.Tag == tag)
                {
                    return mythobjattr;
                }
            }

            return null;
        }

    }
}
