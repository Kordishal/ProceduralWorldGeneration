using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions;

namespace ProceduralWorldGeneration.MythActions.General
{
    class SetCreator : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.CurrentGoal == ActionGoal.CreatePlane)
            {
                taker.CreatedPlane = new Plane();
                taker.CreatedPlane.Creator = taker;

                if (CreationMythState.Planes.Count == 0)
                    taker.CreatedPlane.Tag = Constants.SpecialTags.CORE_WORLD_TAG;

                if (CreationMythState.Planes.Count == 1)
                    taker.CreatedPlane.Tag = Constants.SpecialTags.TRAVEL_DIMENSION_TAG;
            }
            else if (taker.CurrentGoal == ActionGoal.CreateSapientSpecies)
            {
                taker.CreatedSapientSpecies = new SapientSpecies();
                taker.CreatedSapientSpecies.Creator = taker;
            }
            else if(taker.CurrentGoal == ActionGoal.CreateDeity)
            {
                taker.CreadedDeity = new Deity();
                taker.CreadedDeity.Creator = taker;
            }
        }
    }
}
