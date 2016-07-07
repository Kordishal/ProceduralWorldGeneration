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
        private int _infinite_plane_count;

        protected override void AdjustWeight(ActionTakerMythObject taker)
        {
            _weight = 200;

            if (taker.PlaneConstruction.PlaneType.isInfiniteOnly)
                return;

            _infinite_plane_count = 0;
            foreach (Plane p in CreationMythState.Planes)
            {
                if (p.PlaneSize.Name == "infinite")
                    _infinite_plane_count++;
            }

            if (_infinite_plane_count > 10)
                _weight -= 200;

            if (_infinite_plane_count > 5)
                _weight -= 190;

            if (_infinite_plane_count > 2)
                _weight -= 180;

            if (_infinite_plane_count > 1)
                _weight -= 150;
        }

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (!taker.CurrentCreationState.hasType)
                return false;

            if (taker.PlaneConstruction.PlaneType.isAttachedTo != null)
                return false;
            else
                return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (_infinite_plane_count == 0)
                taker.PlaneConstruction.Tag = "travel_dimension";

            taker.PlaneConstruction.PlaneSize = new PlaneSize("infinite");
            taker.PlaneConstruction.PlaneSize.MaxNeighbourPlanes = -1;
            taker.PlaneConstruction.PlaneSize.Name = "Infinite";
            taker.CurrentCreationState.hasSize = true;
        }



    }
}
