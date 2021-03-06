﻿using System.Collections.Generic;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Constants;
using ProceduralWorldGeneration.Main;
using ProceduralWorldGeneration.Attributes;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions
{
    class SetPlaneElement : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CreatedPlane.PlaneType.HasDominantElement)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.CreatedPlane.Tag == SpecialTags.TRAVEL_DIMENSION_TAG)
            {
                taker.CreatedPlane.PlaneElement = Program.DataLoadHandler.SearchElement("air");
                return;
            }

            List<PlaneElement> elements = Program.DataLoadHandler.PlaneElements;
            int plane_element_count = elements.Count;
            int[] spawn_weights = new int[plane_element_count];
            int total_spawn_weight = 0;

            int count = 0;
            foreach (PlaneElement element in elements)
            {
                spawn_weights[count] = element.SpawnWeight;
                total_spawn_weight = total_spawn_weight + element.SpawnWeight;
                count++;
            }

            if (total_spawn_weight == 0)
            {
                total_spawn_weight += 1;
                spawn_weights[0] = 1;
            }


            int chance = ConfigValues.Random.Next(total_spawn_weight);
            int prev_weight = 0, current_weight = 0;
            for (int i = 0; i < plane_element_count; i++)
            {
                current_weight += spawn_weights[i];
                if (prev_weight <= chance && chance < current_weight)
                    taker.CreatedPlane.PlaneElement = elements[i];
                prev_weight = current_weight;
            }

            for (int i = 0; i < plane_element_count; i++)
            {
                if (elements[i] == taker.CreatedPlane.PlaneElement)
                    elements[i].SpawnWeight = spawn_weights[i] - 5;
                else if (elements[i].Opposite == taker.CreatedPlane.PlaneElement.Tag)
                    elements[i].SpawnWeight = spawn_weights[i] + 100;
                else
                    elements[i].SpawnWeight = spawn_weights[i] + 5;
            }
        }
    }
}
