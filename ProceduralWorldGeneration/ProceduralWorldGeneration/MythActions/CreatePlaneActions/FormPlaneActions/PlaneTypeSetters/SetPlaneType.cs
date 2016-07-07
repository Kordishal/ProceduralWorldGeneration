using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjectAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneTypeSetters
{
    abstract class SetPlaneType : PrimitivMythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasType)
                return false;

            if (CreationMythState.Planes.Count < 1)
                return false;
            else
                return true;
        }

        protected PlaneType searchPlaneType(string tag)
        {
            foreach (PlaneType p in CreationMythState.MythObjectData.PlaneTypes)
                if (p.Tag == tag)
                    return p;
            return null;
        }

    }
}
