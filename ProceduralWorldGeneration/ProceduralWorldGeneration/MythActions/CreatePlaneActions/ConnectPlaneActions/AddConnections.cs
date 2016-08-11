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
    class AddConnections : ConnectPlanes
    {
        protected override void AdjustWeight(ActionTakerMythObject taker)
        {
            _weight = 1000;
        }


        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.PlaneConstruction.maxConnectionsReached())
                return false;
            else if (taker.PlaneConstruction.NeighbourPlanes.Count >= CreationMythState.Planes.Count)
                return false;
            else
                return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.PlaneConstruction.PlaneSize.MaxNeighbourPlanes == -1)
            {
                if (taker.PlaneConstruction.Tag == Constants.SpecialTags.TRAVEL_DIMENSION_TAG)
                {
                    foreach (Plane p in CreationMythState.Planes)
                    {
                        if (p.isNotConnectedTo(taker.PlaneConstruction))
                        {
                            taker.PlaneConstruction.connectPlane(p);
                        }
                    }
                    return; 
                }
            }
            else
            {

                
                Plane temp = CreationMythState.Planes[ConfigValues.RandomGenerator.Next(CreationMythState.Planes.Count)];
                while (temp.maxConnectionsReached() || !temp.isNotConnectedTo(taker.PlaneConstruction))
                {
                    temp = CreationMythState.Planes[ConfigValues.RandomGenerator.Next(CreationMythState.Planes.Count)];
                }
                taker.PlaneConstruction.connectPlane(temp);
                    
            }
        }
    }
}
