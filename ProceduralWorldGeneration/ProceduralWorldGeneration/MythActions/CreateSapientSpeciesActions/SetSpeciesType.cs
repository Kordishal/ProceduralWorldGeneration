﻿using System.Collections.Generic;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Main;
using ProceduralWorldGeneration.Attributes;

namespace ProceduralWorldGeneration.MythActions.CreateSapientSpeciesActions
{
    class SetSpeciesType : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            List<SpeciesType> types = Program.DataLoadHandler.SpeciesTypes;
            int species_type_count = types.Count;
            int[] spawn_weights = new int[species_type_count];
            int total_spawn_weight = 0;

            int count = 0;
            foreach (SpeciesType type in types)
            {
                if (type.PlaneType == taker.CreatedSapientSpecies.NativePlane.PlaneType.Tag)
                {
                    spawn_weights[count] = type.SpawnWeight + 200;
                    total_spawn_weight = total_spawn_weight + spawn_weights[count];
                }
                else
                {
                    spawn_weights[count] = type.SpawnWeight;
                    total_spawn_weight = total_spawn_weight + type.SpawnWeight;
                }
                count++;
            }
            
            if (total_spawn_weight == 0)
            {
                total_spawn_weight += 1;
                spawn_weights[0] = 1;
            }


            int chance = ConfigValues.Random.Next(total_spawn_weight);
            int prev_weight = 0, current_weight = 0;
            for (int i = 0; i < species_type_count; i++)
            {
                current_weight += spawn_weights[i];
                if (prev_weight <= chance && chance < current_weight)
                    taker.CreatedSapientSpecies.SpeciesType = Program.DataLoadHandler.SpeciesTypes[i];
                prev_weight = current_weight;
            }

            for (int i = 0; i < species_type_count; i++)
            {
                if (types[i].PlaneType == taker.CreatedSapientSpecies.NativePlane.PlaneType.Tag)
                    types[i].SpawnWeight = spawn_weights[i] - 200;

                if (types[i] == taker.CreatedSapientSpecies.SpeciesType)
                    types[i].SpawnWeight = spawn_weights[i] - 10;
                else
                    types[i].SpawnWeight = spawn_weights[i] + 10;
            }
        }
    }
}
