using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythActions.General;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.ConnectPlaneActions
{
    class AddAdditionalConnection : ConnectPlanes
    {
        protected override void AdjustWeight(ActionTakerMythObject taker)
        {
            _weight = 1000;
        }


        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (CreationMythState.Planes.Count <= 1)
                return false;

            if (taker.CreatedPlane.MaxConnectionsReached())
                return false;

            if (taker.CreatedPlane.NeighbourPlanes.Count >= CreationMythState.Planes.Count)
                return false;

            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.CreatedPlane.Tag == Constants.SpecialTags.TRAVEL_DIMENSION_TAG)
            {
                taker.CreatedPlane.connectPlane(CreationMythState.Planes[0]);
            }
            else
            {            
                Plane temp = CreationMythState.Planes[ConfigValues.Random.Next(CreationMythState.Planes.Count)];
                while (temp.MaxConnectionsReached() || !temp.IsNotConnectedTo(taker.CreatedPlane))
                {
                    temp = CreationMythState.Planes[ConfigValues.Random.Next(CreationMythState.Planes.Count)];
                }
                taker.CreatedPlane.connectPlane(temp);
            }
        }
    }
}
