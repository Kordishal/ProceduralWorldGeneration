using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjectAttributes;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions.PlaneSizeSetters
{
    class SetFinitePlaneSize : SetPlaneSize
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (!taker.CurrentCreationState.hasType)
                return false;

            if (taker.PlaneConstruction.PlaneType.isInfiniteOnly)
                return false;

            if (taker.PlaneConstruction.PlaneType.isAttachedTo == null)
                return true;
            else
                return false; ;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.PlaneConstruction.Tag == "core_plane")
            {
                taker.PlaneConstruction.PlaneSize = CreationMythState.MythObjectData.PlaneSizes[CreationMythState.MythObjectData.PlaneSizes.Count - 1];
                taker.CurrentCreationState.hasSize = true;
                return;
            }


            int total_spawn_weight = 0;

            foreach (PlaneSize s in CreationMythState.MythObjectData.PlaneSizes)
            {
                total_spawn_weight = total_spawn_weight + s.SpawnWeight;
            }

            int chance = ConfigValues.RandomGenerator.Next(total_spawn_weight);
            int prev_weight = 0;
            int current_weight = 0;
            foreach (PlaneSize s in CreationMythState.MythObjectData.PlaneSizes)
            {
                current_weight = current_weight + s.SpawnWeight;
                if (prev_weight <= chance && chance < current_weight)
                    taker.PlaneConstruction.PlaneSize = s;

                prev_weight = current_weight;
            }
            taker.CurrentCreationState.hasSize = true;
        }
    }
}
