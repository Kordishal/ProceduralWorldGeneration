﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneElementSetters
{
    class SetLightElement : SetPlaneElement
    {
        public override void Effect(ActionTakerMythObject taker)
        {
            taker.PlaneConstruction.PlaneElement = searchElement("light");
            taker.CurrentCreationState.hasElement = true;
        }
    }
}