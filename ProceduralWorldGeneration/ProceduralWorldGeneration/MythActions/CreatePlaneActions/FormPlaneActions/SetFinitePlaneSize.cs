using ProceduralWorldGeneration.Attributes;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Main;
using ProceduralWorldGeneration.MythObjects;
using System.Linq;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions
{
    class SetFinitePlaneSize : SetPlaneSize
    {
        protected override void AdjustWeight(ActionTakerMythObject taker)
        {
            _weight = 10 + 10 * CreationMythState.Planes.Count;
        }


        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CreatedPlane.PlaneType == null)
                return false;

            if (taker.CreatedPlane.PlaneType.IsIntegrated == null)
                return true;
            else
                return false; ;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.CreatedPlane.Tag == Constants.SpecialTags.CORE_WORLD_TAG)
            {
                taker.CreatedPlane.PlaneSize = Program.DataLoadHandler.PlaneSizes[Program.DataLoadHandler.PlaneSizes.Count - 1];
                return;
            }


            int total_spawn_weight = 0;

            foreach (PlaneSize s in Program.DataLoadHandler.PlaneSizes)
            {
                total_spawn_weight = total_spawn_weight + s.SpawnWeight;
            }

            int chance = ConfigValues.Random.Next(total_spawn_weight);
            int prev_weight = 0;
            int current_weight = 0;
            foreach (PlaneSize s in Program.DataLoadHandler.PlaneSizes)
            {
                current_weight = current_weight + s.SpawnWeight;
                if (prev_weight <= chance && chance < current_weight)
                    taker.CreatedPlane.PlaneSize = s;

                prev_weight = current_weight;
            }
        }
    }
}
