using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneTypeSetters
{
    class SetElementalType : SetPlaneType
    {

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.PlaneConstruction.PlaneType = searchPlaneType("elemental");
            taker.CurrentCreationState.hasType = true;
        }
    }
}
