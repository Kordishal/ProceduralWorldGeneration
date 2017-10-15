using System;
using System.Linq;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Main;

namespace ProceduralWorldGeneration.MythActions.CreateDeityActions
{
    class SetPersonality : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.CreadedDeity.Personality = Program.DataLoadHandler.Personalities[ConfigValues.Random.Next(Program.DataLoadHandler.Personalities.Count)];
        }
    }
}
