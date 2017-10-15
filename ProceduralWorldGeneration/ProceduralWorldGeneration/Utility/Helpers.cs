using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Utility
{
    class Helpers
    {

        public static string ListToString(List<string> list)
        {
            if (list == null)
                return "";

            var result = "";
            int i = 0;
            if (list.Count == 1)
                return result += list[0];
            else if (list.Count == 0)
                return "";
            else
            {
                for (i = 0; i < list.Count - 1; i++)
                    result += list[i] + ", ";
                result += list[i];
                return result;
            }
        }

    }
}
