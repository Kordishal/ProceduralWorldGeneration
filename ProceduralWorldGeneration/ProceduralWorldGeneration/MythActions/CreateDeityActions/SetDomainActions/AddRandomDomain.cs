using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Generator;

namespace ProceduralWorldGeneration.MythActions.CreateDeityActions.SetDomainActions
{
    class AddRandomDomain : MythAction
    {

        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.DeityCreation.Domains.Add(CreationMythState.MythObjectData.Domains[ConfigValues.RandomGenerator.Next(CreationMythState.MythObjectData.Domains.Count)]);
        }
    }
}
