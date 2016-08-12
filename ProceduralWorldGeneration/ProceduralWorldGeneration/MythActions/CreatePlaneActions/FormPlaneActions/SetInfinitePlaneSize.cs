using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions
{
    class SetInfinitePlaneSize : SetPlaneSize
    {
        protected override void AdjustWeight(ActionTakerMythObject taker)
        {
            _weight = 10;
        }

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CreatedPlane.PlaneType.isInfiniteOnly)
                return true;

            if (taker.CreatedPlane.Tag == Constants.SpecialTags.CORE_WORLD_TAG)
                return false;

            if (taker.CreatedPlane.Tag == Constants.SpecialTags.TRAVEL_DIMENSION_TAG)
                return true;

            if (taker.CreatedPlane.PlaneType.isAttachedTo != null)
                return false;
            else
                return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.CreatedPlane.PlaneSize = new PlaneSize(Constants.SpecialTags.INFINITE_PLANE_SIZE);
            taker.CreatedPlane.PlaneSize.MaxNeighbourPlanes = -1;
            taker.CreatedPlane.PlaneSize.Name = "Infinite";
        }



    }
}
