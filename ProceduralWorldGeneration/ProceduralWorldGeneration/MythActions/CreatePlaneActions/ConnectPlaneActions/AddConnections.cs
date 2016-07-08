using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
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
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasFirstConnection)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.PlaneConstruction.PlaneSize.MaxNeighbourPlanes == -1)
            {
                if (taker.PlaneConstruction.Tag == "travel_dimension")
                {
                    foreach (Plane p in CreationMythState.Planes)
                    {
                        if (p.isNotConnectedTo(taker.PlaneConstruction))
                        {
                            taker.PlaneConstruction.connectPlane(p);
                        }
                    }

                    taker.CurrentCreationState.isConnected = true;
                    return; 
                }
                else
                {
                    taker.CurrentCreationState.isConnected = true;
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

                if (taker.PlaneConstruction.maxConnectionsReached())
                    taker.CurrentCreationState.isConnected = true;
            }
        }
    }
}
