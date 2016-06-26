using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;

namespace ProceduralWorldGeneration.MythObjects
{
    class Species : ActionTakerMythObject
    {

        static public string TYPE = "SPECIES";




        private bool _is_sentient;
        private bool _is_sapient;

        public Species()
        {


        }


        public override void takeAction(CreationMythState creation_myth, int current_year)
        {

        }
    }
}
