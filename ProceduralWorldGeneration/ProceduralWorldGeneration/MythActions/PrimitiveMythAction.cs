using ProceduralWorldGeneration.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions
{
    abstract class PrimitivMythAction : MythAction
    {
        public PrimitivMythAction() : base()
        {
            _is_primitve = true;
        }
    }
}
