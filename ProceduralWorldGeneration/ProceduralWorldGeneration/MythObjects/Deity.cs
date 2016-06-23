using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.DataStructure;

namespace ProceduralWorldGeneration.MythObjects
{
    class Deity : ActionableBaseMythObject
    {

        public static string TYPE = "DEITY";


        public Deity() : base()
        {
            base.Type = TYPE;
        }

        public override void takeAction(CreationMyth creation_myth, int current_year, Random rnd)
        {
            throw new NotImplementedException();
        }
    }
}
