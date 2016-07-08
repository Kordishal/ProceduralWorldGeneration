using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class SetCreator : PrimitivMythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (!taker.CurrentCreationState.hasCreator)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.CurrentGoal == ActionGoal.CreatePlane)
            {
                taker.PlaneConstruction = new Plane();
                taker.PlaneConstruction.Creator = taker;
                taker.CurrentCreationState.hasCreator = true;
                taker.CurrentCreationState.isCreatingPlane = true;

                if (CreationMythState.Planes.Count == 0)
                    taker.PlaneConstruction.Tag = "core_plane";

                if (CreationMythState.Planes.Count == 1)
                    taker.PlaneConstruction.Tag = "travel_dimension";
            }
            else if (taker.CurrentGoal == ActionGoal.CreateSapientSpecies)
            {
                taker.SapientSpeciesCreation = new SapientSpecies();
                taker.SapientSpeciesCreation.Creator = taker;
                taker.CurrentCreationState.hasCreator = true;
                taker.CurrentCreationState.isCreatingSapientSpecies = true;
            }
            else if(taker.CurrentGoal == ActionGoal.CreateDeity)
            {
                taker.DeityCreation = new Deity();
                taker.DeityCreation.Creator = taker;
                taker.CurrentCreationState.hasCreator = true;
                taker.CurrentCreationState.isCreatingDeity = true;
            }
        }
    }
}
