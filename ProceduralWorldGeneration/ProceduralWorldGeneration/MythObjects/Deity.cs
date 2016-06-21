using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjects
{
    class Deity : BaseMythObject, IAction
    {

        public static string TYPE = "DEITY";


        public Deity() : base()
        {
            base.Type = TYPE;
        }


        public void takeAction()
        {
            throw new NotImplementedException();
        }
    }
}
