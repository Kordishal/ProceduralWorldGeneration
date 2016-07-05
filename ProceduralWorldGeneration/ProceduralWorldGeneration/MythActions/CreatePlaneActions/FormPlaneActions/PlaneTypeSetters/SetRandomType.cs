﻿using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjectAttributes;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneTypeSetters
{
    class SetRandomType : MythAction
    {
        public SetRandomType() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            if (state.Planes.Count > 0)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            PrimordialForce _taker = (PrimordialForce)taker;
            _taker.PlaneConstruction.PlaneType = state.MythObjectData.PlaneTypes[ConfigValues.RandomGenerator.Next(state.MythObjectData.PlaneTypes.Count)];
            _taker.PlaneConstructionState.hasType = true;
        }
    }
}
