using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;

namespace ProceduralWorldGeneration.MythActions.CreateDeityActions
{
    class SetPersonality : MythAction
    {
        public SetPersonality()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasTraits && !taker.CurrentCreationState.hasPersonality)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            taker.DeityCreation.Personality = state.MythObjectData.Personalities[ConfigValues.RandomGenerator.Next(state.MythObjectData.Personalities.Count)];
            taker.CurrentCreationState.hasPersonality = true;
        }
    }
}
