using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.DataStructure;

namespace ProceduralWorldGeneration.MythActions
{
    abstract class NonPrimitiveMythAction : MythAction
    {
        public NonPrimitiveMythAction() : base()
        {
            _is_primitve = false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {

        }
    }
}
