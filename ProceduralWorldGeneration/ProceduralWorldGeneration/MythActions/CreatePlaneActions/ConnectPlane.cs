using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class ConnectPlane : NonPrimitiveMythAction 
    {

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            if (_taker.CurrentCreationState.formedPlane && !_taker.CurrentCreationState.isConnected)
                return true;
            else
                return false;

        }

        protected Plane searchPlaneSize(string size)
        {
            List<Plane> temp = new List<Plane>();
            foreach (Plane p in CreationMythState.Planes)
                if (p.PlaneSize != null && p.PlaneSize.Tag == size)
                    temp.Add(p);

            if (temp.Count <= 0)
                return null;
            else
                return temp[ConfigValues.RandomGenerator.Next(temp.Count)];
        }

        protected Plane searchPlaneType(string type)
        {
            List<Plane> temp = new List<Plane>();
            foreach (Plane p in CreationMythState.Planes)
                if (p.PlaneType.Tag == type)
                    temp.Add(p);

            if (temp.Count <= 0)
                return null;
            else
                return temp[ConfigValues.RandomGenerator.Next(temp.Count)];
        }
    }
}
