using ProceduralWorldGeneration.MythObjectAttributes;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.DataStructure
{
    public class MythObjectData
    {

        public List<BaseMythObject> DefinedMythObjects { get; set; }
        public List<MythObjectAttribute> MythObjectAttributes { get; set; }

        // PRIMORDIAL FORCES
        public List<PrimordialForce> PrimordialForces { get; set; }

        // DEITIES
        public List<string> Domains { get; set; }
        public List<string> Personalities { get; set; }

        // PLANES
        public List<Plane> DefinedPlanes { get; set; }

        public List<PlaneType> PlaneTypes { get; set; }
        public List<PlaneSize> PlaneSizes { get; set; }
        public List<PlaneElement> PlaneElements { get; set; }

        // SPECIES
        public List<Ethos> Ethoses { get; set; }
        public List<Trait> Traits { get; set; }



        public MythObjectData()
        {
            DefinedMythObjects = new List<BaseMythObject>();
            MythObjectAttributes = new List<MythObjectAttribute>();
            PrimordialForces = new List<PrimordialForce>();
            Domains = new List<string>();
            Personalities = new List<string>();
            Traits = new List<Trait>();
            PlaneTypes = new List<PlaneType>();
            PlaneSizes = new List<PlaneSize>();
            PlaneElements = new List<PlaneElement>();
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
