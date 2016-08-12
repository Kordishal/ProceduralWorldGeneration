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

        static public PlaneType searchPlaneType(string tag)
        {
            foreach (PlaneType p in CreationMythState.MythObjectData.PlaneTypes)
                if (p.Tag == tag)
                    return p;
            return null;
        }
        static public PlaneElement searchElement(string tag)
        {
            foreach (PlaneElement p in CreationMythState.MythObjectData.PlaneElements)
                if (p.Tag == tag)
                    return p;
            return null;
        }

        // SPECIES
        public List<SpeciesType> SpeciesTypes { get; set; }
        public List<CivilisationEthos> Ethoses { get; set; }
        public List<SpeciesTrait> Traits { get; set; }
        public List<TraitCategory> TraitCategories { get; set; }



        public MythObjectData()
        {
            DefinedMythObjects = new List<BaseMythObject>();
            MythObjectAttributes = new List<MythObjectAttribute>();
            PrimordialForces = new List<PrimordialForce>();
            Domains = new List<string>();
            Personalities = new List<string>();
            Traits = new List<SpeciesTrait>();
            PlaneTypes = new List<PlaneType>();
            PlaneSizes = new List<PlaneSize>();
            PlaneElements = new List<PlaneElement>();
            SpeciesTypes = new List<SpeciesType>();
            TraitCategories = new List<TraitCategory>();
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
