using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions
{
    class CreatePlane : MythAction
    {
        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            if (taker.GetType() == typeof(PrimordialForce))
            {
                if ((taker as PrimordialForce).HasGatheredPower)
                {
                    return true;
                }
            }

            return false;
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            // Always first add the core world
            if (state.Planes.Count == 0)
            {
                addDefinedPlane("The Core World", state, taker);
                return;
            }
            // Once the core world is added, the primordial powers add their respective ethereal planes to the core world.
            //if (Name == "Light" && !_has_created_defined_ethereal_plane)
            //{
            //    addDefinedPlane("Plane of Light", creation_myth);
            //    _has_created_defined_ethereal_plane = true;
            //    return;
            //}
            //if (Name == "Darkness" && !_has_created_defined_ethereal_plane)
            //{
            //    addDefinedPlane("Shadow Plane", creation_myth);
            //    _has_created_defined_ethereal_plane = true;
            //    return;
            //}
            //if (Name == "Chaos" && !_has_created_defined_ethereal_plane)
            //{
            //    addDefinedPlane("Plane of Entropy", creation_myth);
            //    _has_created_defined_ethereal_plane = true;
            //    return;
            //}
            //if (Name == "Order" && !_has_created_defined_ethereal_plane)
            //{
            //    addDefinedPlane("Plane of Harmony", creation_myth);
            //    _has_created_defined_ethereal_plane = true;
            //    return;
            //}
            //// After there is a 40% chance to add the astral plane.
            //if (ConfigValues.RandomGenerator.Next(100) < 40 && !_has_created_astral_plane)
            //{
            //    addDefinedPlane("Astral Plane", creation_myth);
            //    _has_created_astral_plane = true;
            //    return;
            //}
        }

        private void addDefinedPlane(string name, CreationMythState creation_myth, BaseMythObject taker)
        {
            foreach (Plane p in creation_myth.MythObjectData.DefinedPlanes)
            {
                if (p.Name == name)
                {
                    p.Creator = taker;
                    p.connectPlane(creation_myth.Planes);
                    creation_myth.Planes.Add(p);
                    creation_myth.MythObjects.Add(p);
                    creation_myth.MythObjectData.DefinedPlanes.Remove(p);
                    creation_myth.Logger.updateLog(p, "CREATED");
                    break;
                }
            }
        }
    }
}
