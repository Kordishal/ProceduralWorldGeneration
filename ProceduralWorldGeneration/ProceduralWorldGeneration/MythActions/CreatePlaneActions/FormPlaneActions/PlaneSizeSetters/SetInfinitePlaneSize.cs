using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters
{
    class SetInfinitePlaneSize : SetPlaneSize
    {
        protected override void AdjustWeight(ActionTakerMythObject taker)
        {
            _weight = 10;
        }

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.PlaneConstruction.Tag == Constants.SpecialTags.CORE_WORLD_TAG)
                return false;

            if (taker.PlaneConstruction.Tag == Constants.SpecialTags.TRAVEL_DIMENSION_TAG)
                return true;

            if (!taker.CurrentCreationState.hasType)
                return false;

            if (taker.CurrentCreationState.hasSize)
                return false;

            if (taker.PlaneConstruction.PlaneType.isAttachedTo != null)
                return false;
            else
                return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.PlaneConstruction.PlaneSize = new PlaneSize(Constants.SpecialTags.INFINITE_PLANE_SIZE);
            taker.PlaneConstruction.PlaneSize.MaxNeighbourPlanes = -1;
            taker.PlaneConstruction.PlaneSize.Name = "Infinite";
            taker.CurrentCreationState.hasSize = true;
        }



    }
}
