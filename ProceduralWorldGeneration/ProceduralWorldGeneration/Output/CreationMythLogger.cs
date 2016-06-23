using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Output
{
    class CreationMythLogger
    {
        public StreamWriter writer;

        private List<string> _temp_log = new List<string>();


        public CreationMythLogger()
        {


        }

        public void Write()
        {
            writer = new StreamWriter(@"C:\Users\Jonas\Documents\Projekte\ProceduralWorldGeneration\logs\myth_creation.log");
            foreach (string s in _temp_log)
            {
                writer.WriteLine(s);
            }         
            writer.Close();
            _temp_log.Clear();
        }

        public void updateLog(string line)
        {
            _temp_log.Add(line);
        }

        public void updateLog(BaseMythObject myth_object, string action)
        {
            _temp_log.Add(action + ": " + myth_object.ToString());
        }

        public void updateLog(int current_year)
        {
            _temp_log.Add("YEAR: " + current_year);
        }
    }
}
