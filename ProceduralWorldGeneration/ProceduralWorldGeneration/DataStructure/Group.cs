using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.DataStructure
{
    class Group
    {
        public int Identifier;
        public string Name;
        public List<Group> SubGroups;

        public Group(int id, string name)
        {
            Identifier = id;
            Name = name;
            SubGroups = new List<Group>();
        }
    }
}
