using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Main;

namespace ProceduralWorldGeneration.MythActions.CreateDeityActions
{
    class AddRandomDomain : MythAction
    {

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (taker.CreadedDeity.Domains.Count > 5)
                return false;
            else
                return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.CreadedDeity.Domains.Add(Program.DataLoadHandler.Domains[ConfigValues.Random.Next(Program.DataLoadHandler.Domains.Count)]);
        }
    }
}
