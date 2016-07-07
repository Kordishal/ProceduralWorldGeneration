using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjectAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters
{
    abstract class SetPlaneSize : PrimitivMythAction
    {

        protected PlaneSize searchSize(string tag)
        {
            foreach (PlaneSize p in CreationMythState.MythObjectData.PlaneSizes)
                if (p.Tag == tag)
                    return p;
            return null;
        }
    }
}
