using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Elements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Input
{
    class MainInputReader
    {
        const string DIRECTORY_PATH = @"C:\Users\Jonas\Documents\Projekte\ProceduralWorldGeneration\Elements\";
        const string GROUP_ID_FILE = @"group_ids.csv";

        public MainInputReader(ElementGroups elements)
        {
            createElementGroups(elements);
            createGroups(elements);
        }

        private void createGroups(ElementGroups elements)
        {
            List<string> files;
            files = ReadFile(DIRECTORY_PATH + GROUP_ID_FILE);

            // create all groups
            foreach (string s in files)
            {
                string[] temp = s.Split(';');
                elements.Groups.Add(new Group(int.Parse(temp[0]), temp[1]));
            }
            // Add subgroups to groups.
            for (int i = 0; i < elements.Groups.Count; i++)
            {
                string[] temp = files[i].Split(';');
                // Go through the possible subgroups currently there are ten per group.
                for (int j = 3; j < 12; j++)
                {
                    if (temp[j] != "-")
                    {
                        elements.Groups[i].SubGroups.Add(elements.Groups[int.Parse(temp[j]) - 1]);
                    }
                }
            }
        }

        private void createElementGroups(ElementGroups elements)
        {
            List<string> files;
            List<string> lines;
            List<Element> element_list;

            files = ReadFile(DIRECTORY_PATH + GROUP_ID_FILE);

            foreach (string s in files)
            {
                lines = ReadFile(DIRECTORY_PATH + s.Split(';')[2]);
                element_list = new List<Element>();
                string[] temp;
                for (int i = 0; i < lines.Count; i++)
                {
                    temp = lines[i].Split(';');
                    element_list.Add(new Element());
                    element_list[i].GroupIdentifier = int.Parse(s.Split(';')[0]);
                    element_list[i].Name = temp[0];
                    element_list[i].PluralName = temp[1];
                    element_list[i].MinSize = int.Parse(temp[2]);
                    element_list[i].MaxSize = int.Parse(temp[3]);
                }
                elements.Elements.Add(element_list);
            }      
        }

        private List<string> ReadFile(string path)
        {
            List<string> result = new List<string>();
            StreamReader reader = new StreamReader(path);

            // Header information
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                result.Add(reader.ReadLine());
            }

            reader.Close();

            return result;
        }
    }
}
