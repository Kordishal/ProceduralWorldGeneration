using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjectAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions
{
    class SetPlaneType : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentGoal == ActionGoal.CreatePlane)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.CreatedPlane.Tag == Constants.SpecialTags.CORE_WORLD_TAG)
            {
                taker.CreatedPlane.PlaneType = MythObjectData.searchPlaneType("material");
                return;
            }

            if (taker.CreatedPlane.Tag == Constants.SpecialTags.TRAVEL_DIMENSION_TAG)
            {
                taker.CreatedPlane.PlaneType = MythObjectData.searchPlaneType("elemental");
                return;
            }

            List<PlaneType> types = CreationMythState.MythObjectData.PlaneTypes;
            int plane_type_count = types.Count;
            int[] spawn_weights = new int[plane_type_count];
            int total_spawn_weight = 0;

            int count = 0;
            foreach (PlaneType type in types)
            {
                spawn_weights[count] = type.SpawnWeight;
                total_spawn_weight = total_spawn_weight + type.SpawnWeight;
                count++;
            }

            if (total_spawn_weight == 0)
            {
                total_spawn_weight += 1;
                spawn_weights[0] = 1;
            }


            int chance = ConfigValues.Random.Next(total_spawn_weight);
            int prev_weight = 0, current_weight = 0;
            for (int i = 0; i < plane_type_count; i++)
            {
                current_weight += spawn_weights[i];
                if (prev_weight <= chance && chance < current_weight)
                    taker.CreatedPlane.PlaneType = types[i];
                prev_weight = current_weight;
            }

            for (int i = 0; i < plane_type_count; i++)
            {
                if (types[i] == taker.CreatedPlane.PlaneType)
                    types[i].SpawnWeight = spawn_weights[i] - 5;
                else
                    types[i].SpawnWeight = spawn_weights[i] + 5;
            }
        }
    }
}
