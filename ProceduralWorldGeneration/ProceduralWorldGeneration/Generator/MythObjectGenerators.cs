using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    class MythObjectGenerators
    {

        public PlaneGenerator PlaneGenerator { get; set; }

        public DeityGenerator DeityGenerator { get; set; }


        public MythObjectGenerators()
        {
            PlaneGenerator = new PlaneGenerator();
            DeityGenerator = new DeityGenerator();
        }


    }
}
