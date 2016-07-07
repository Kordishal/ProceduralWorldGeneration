using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneElementSetters
{
    abstract class SetPlaneElement : PrimitivMythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (!taker.CurrentCreationState.hasType)
                return false;
            if (taker.CurrentCreationState.hasElement)
                return false;

            if (taker.PlaneConstruction.PlaneType.hasDominantElement)
                return true;
            else
                return false;
        }

        protected PlaneElement searchElement(string tag)
        {
            foreach (PlaneElement p in CreationMythState.MythObjectData.PlaneElements)
                if (p.Tag == tag)
                    return p;
            return null;
        }

        protected bool findPlane(string plane_element)
        {
            return true;
        }

    }
}
