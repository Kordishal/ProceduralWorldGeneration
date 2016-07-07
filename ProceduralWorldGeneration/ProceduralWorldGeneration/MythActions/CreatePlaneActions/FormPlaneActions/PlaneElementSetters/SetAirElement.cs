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
    class SetAirElement : SetPlaneElement
    {

        protected override void AdjustWeight(ActionTakerMythObject taker)
        {
            _weight = 10;           
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.PlaneConstruction.PlaneElement = searchElement("air");
            taker.CurrentCreationState.hasElement = true;
        }

        
    }
}
