﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions
{
    class CreatePlane : MythAction
    {
        protected Plane _plane;

        protected string _name;

        public CreatePlane() : base() {
            _plane = new Plane();
            _name = "";
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            if (taker.GetType() == typeof(PrimordialForce) && state.Planes.Count >= 1)
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


        }

        private bool searchCreatedPlane(string name, CreationMythState state)
        {
            foreach (Plane plane in state.Planes)
            {
                if (plane.Name == name)
                {
                    return true;
                }
            }
            return false;
        }


        protected void determinePlaneType(int material_weight, int ethereal_weight, int elemental_weight, CreationMythState state)
        {
            int total_weight = material_weight + ethereal_weight + elemental_weight;
            int chance = ConfigValues.RandomGenerator.Next(total_weight);

            if (chance < material_weight)
            {
                _plane.PlaneType = (PlaneType)state.MythObjectData.searchAttribute("material");
                _name += "Material Plane of ";
            }
            else if (chance > material_weight && chance < material_weight + ethereal_weight)
            {
                _plane.PlaneType = (PlaneType)state.MythObjectData.searchAttribute("ethereal");
                _name += "Ethereal Plane of ";
            }
            else if (chance > material_weight + ethereal_weight && chance < total_weight)
            {
                _plane.PlaneType = (PlaneType)state.MythObjectData.searchAttribute("elemental");
                _name += "Elemental Plane of ";
            }
        }

        protected void determinePlaneElement(CreationMythState state)
        {
            if (_plane.PlaneType.Tag == "material")
            {
                return;
            }
        }

        protected void addName()
        {
            _plane.Name = _name;
        }

        protected void addCreatedPlaneToState(CreationMythState state)
        {
            state.MythObjects.Add(_plane);
            state.Planes.Add(_plane);
            state.Logger.updateLog(_plane, "Created");
        }

    }
}
