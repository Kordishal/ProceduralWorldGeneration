using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjects
{
    class Plane : BaseMythObject
    {

        public static string TYPE = "PLANE";

        public Plane() : base()
        {
            base.Type = TYPE;

        }

    }
}
