using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;

namespace ProceduralWorldGeneration.MythActions.CreateDeityActions.SetTraitActions
{
    class AddRandomTrait : MythAction
    {

        private int _max_trait_points_deites = 10;
        private int _current_trait_points;

        public AddRandomTrait() : base()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasDomains && !taker.CurrentCreationState.hasTraits)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            if (_current_trait_points < _max_trait_points_deites)
            {
                taker.DeityCreation.Traits.Add(state.MythObjectData.Traits[ConfigValues.RandomGenerator.Next(state.MythObjectData.Traits.Count)]);
                _current_trait_points += 1;
            }
            else
            {
                taker.CurrentCreationState.hasTraits = true;
                _current_trait_points = 0;
            }
        }
    }
}
