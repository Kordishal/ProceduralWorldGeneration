using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreateSapientSpeciesActions
{
    class AddTrait : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CreatedSapientSpecies.Traits.Count < 3)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            
        }
    }
}
