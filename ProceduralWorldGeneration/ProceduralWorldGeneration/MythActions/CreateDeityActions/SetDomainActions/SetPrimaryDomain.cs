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
    class SetPrimaryDomain : PrimitivMythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            if (!taker.CurrentCreationState.hasPrimaryDomain)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            taker.DeityCreation.Domains.Add(CreationMythState.MythObjectData.Domains[ConfigValues.RandomGenerator.Next(CreationMythState.MythObjectData.Domains.Count)]);
            taker.CurrentCreationState.hasPrimaryDomain = true;
        }
    }
}
