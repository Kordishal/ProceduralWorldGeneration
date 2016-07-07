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
    class ConnectPlane : MythAction 
    {
        public ConnectPlane() : base()
        {
            _is_primitve = false;
        }


        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            if (_taker.CurrentCreationState.formedPlane && !_taker.CurrentCreationState.isConnected)
                return true;
            else
                return false;

        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            
        }

        protected Plane searchPlaneSize(List<Plane> planes, string size)
        {
            List<Plane> temp = new List<Plane>();
            foreach (Plane p in planes)
                if (p.PlaneSize != null && p.PlaneSize.Tag == size)
                    temp.Add(p);

            if (temp.Count <= 0)
                return null;
            else
                return temp[ConfigValues.RandomGenerator.Next(temp.Count)];
        }

        protected Plane searchPlaneType(List<Plane> planes, string type)
        {
            List<Plane> temp = new List<Plane>();
            foreach (Plane p in planes)
                if (p.PlaneType.Tag == type)
                    temp.Add(p);

            if (temp.Count <= 0)
                return null;
            else
                return temp[ConfigValues.RandomGenerator.Next(temp.Count)];
        }
    }
}
