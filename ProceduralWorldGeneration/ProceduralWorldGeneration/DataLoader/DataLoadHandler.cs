using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProceduralWorldGeneration.Attributes;
using System.IO;
using System.Diagnostics;

namespace ProceduralWorldGeneration.DataLoader
{
    public class DataLoadHandler
    {
        private string DataFileBasePath;

        private const string _domains = @"deity_attributes\domains.json";

        private const string _plane_elements = @"plane_attributes\plane_elements.json";
        private const string _plane_types = @"plane_attributes\plane_types.json";
        private const string _plane_sizes = @"plane_attributes\plane_sizes.json";

        private const string _species_types = @"species_attributes\species_types.json";

        private const string _traits_elemental = @"species_attributes\elemental_traits.json";
        private const string _traits_habitat = @"species_attributes\habitat_traits.json";
        private const string _traits_life_expectancy = @"species_attributes\life_expectance_traits.json";
        private const string _traits_physical = @"species_attributes\physical_traits.json";

        private const string _traits_categories = @"species_attributes\trait_categories.json";

        private const string _civilization_ethos = @"civilization_attributes\ethos.json";

        public DataLoadHandler(string path=@"C:\Users\jwaeb\Documents\Projects\UniverseGeneration\data_files\")
        {
            Debug.Assert(Directory.Exists(path));
            Debug.Assert(File.Exists(path + _domains));
            Debug.Assert(File.Exists(path + _plane_elements));
            Debug.Assert(File.Exists(path + _plane_sizes));
            Debug.Assert(File.Exists(path + _plane_types));
            Debug.Assert(File.Exists(path + _civilization_ethos));
            DataFileBasePath = path;
        }

        public List<Domain> Domains { get; set; }

        public List<PlaneElement> PlaneElements { get; set; }
        public List<PlaneSize> PlaneSizes { get; set; }
        public List<PlaneType> PlaneTypes { get; set; }

        public List<SpeciesTrait> SpeciesTraits { get; set; }
        public List<SpeciesType> SpeciesTypes { get; set; }

        public List<TraitCategories> TraitCategories { get; set; }

        public List<CivilizationEthos> CivilizationEthos { get; set; }

        public void ReadDataFiles()
        {
            // TODO: Add function to controll whether the input is correct.
            Domains = ReadFile<Domain>(_domains);

            PlaneElements = ReadFile<PlaneElement>(_plane_elements);
            PlaneSizes = ReadFile<PlaneSize>(_plane_sizes);
            PlaneTypes = ReadFile<PlaneType>(_plane_types);

            SpeciesTraits = ReadFile<SpeciesTrait>(_traits_elemental);
            SpeciesTraits.AddRange(ReadFile<SpeciesTrait>(_traits_habitat));
            SpeciesTraits.AddRange(ReadFile<SpeciesTrait>(_traits_life_expectancy));
            SpeciesTraits.AddRange(ReadFile<SpeciesTrait>(_traits_physical));

            SpeciesTypes = ReadFile<SpeciesType>(_species_types);

            TraitCategories = ReadFile<TraitCategories>(_traits_categories);

            CivilizationEthos = ReadFile<CivilizationEthos>(_civilization_ethos);



            Debug.Assert(Domains.TrueForAll(x => x != null));

            Debug.Assert(PlaneElements.TrueForAll(x => x != null));
            Debug.Assert(PlaneSizes.TrueForAll(x => x != null));
            Debug.Assert(PlaneTypes.TrueForAll(x => x != null));

            Debug.Assert(SpeciesTypes.TrueForAll(x => x != null));
            Debug.Assert(SpeciesTraits.TrueForAll(x => x != null));

            Debug.Assert(TraitCategories.TrueForAll(x => x != null));

            Debug.Assert(CivilizationEthos.TrueForAll(x => x != null));
        }

        private List<T> ReadFile<T>(string path)
        {
            var results = new List<T>();
            foreach (string s in new StreamReader(DataFileBasePath + path).ReadToEnd().Split(';'))
            {
                if (s.Contains('{'))
                    results.Add(JsonConvert.DeserializeObject<T>(s));
            }

            return results;
        }

    }
}
