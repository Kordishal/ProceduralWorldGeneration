using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;


namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneElementSetters
{
    class SetNoPlaneElement : SetPlaneElement
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (!taker.PlaneConstruction.PlaneType.hasDominantElement)
                return true;
            else
                return false;

        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.PlaneConstruction.PlaneElement = null;
        }
    }
}
