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
    class SetPersonality : PrimitivMythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasDomains && !taker.CurrentCreationState.hasPersonality)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.DeityCreation.Personality = CreationMythState.MythObjectData.Personalities[ConfigValues.RandomGenerator.Next(CreationMythState.MythObjectData.Personalities.Count)];
            taker.CurrentCreationState.hasPersonality = true;
        }
    }
}
