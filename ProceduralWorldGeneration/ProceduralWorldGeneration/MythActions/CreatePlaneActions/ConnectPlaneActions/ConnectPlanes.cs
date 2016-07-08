using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.ConnectPlaneActions
{
    abstract class ConnectPlanes : PrimitivMythAction
    {
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


        protected Plane searchPlaneTag(string tag)
        {
            Plane temp = new Plane();
            foreach (Plane p in CreationMythState.Planes)
                if (p.Tag == tag)
                    return p;

            return null;
        }
    }
}
