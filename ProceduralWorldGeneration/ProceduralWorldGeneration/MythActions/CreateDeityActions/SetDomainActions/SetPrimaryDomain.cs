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
    class SetPrimaryDomain : MythAction
    {
        public SetPrimaryDomain()
        {
            _is_primitve = true;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if (!taker.CurrentCreationState.hasPrimaryDomain)
                return true;
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            taker.DeityCreation.Domains.Add(state.MythObjectData.Domains[ConfigValues.RandomGenerator.Next(state.MythObjectData.Domains.Count)]);
            taker.CurrentCreationState.hasPrimaryDomain = true;
        }
    }
}
