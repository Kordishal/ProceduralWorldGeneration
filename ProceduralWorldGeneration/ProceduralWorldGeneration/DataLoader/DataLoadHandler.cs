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

        public DataLoadHandler(string path=@"C:\Users\jwaeb\Documents\Projects\UniverseGeneration\data_files\")
        {
            Debug.Assert(Directory.Exists(path));
            Debug.Assert(File.Exists(path + _domains));
            Debug.Assert(File.Exists(path + _plane_elements));
            DataFileBasePath = path;
        }

        public List<Domain> Domains { get; set; }

        public void ReadDomainFile()
        {
            var reader = new StreamReader(DataFileBasePath + _domains);
            var json = reader.ReadToEnd();
            var elements = json.Split(';');
            Domains = new List<Domain>();
            foreach (string s in elements)
                if (s != "")
                    Domains.Add(JsonConvert.DeserializeObject<Domain>(s));
        }

        public List<PlaneElement> PlaneElements { get; set; }

        public void ReadPlaneElementFile()
        {
            var reader = new StreamReader(DataFileBasePath + _plane_elements);
            var json = reader.ReadToEnd();
            var elements = json.Split(';');
            PlaneElements = new List<PlaneElement>();
            foreach (string s in elements)
            {
                Debug.Print(s);
                if (s != "")
                    PlaneElements.Add(JsonConvert.DeserializeObject<PlaneElement>(s));
            }
        }

    }
}
