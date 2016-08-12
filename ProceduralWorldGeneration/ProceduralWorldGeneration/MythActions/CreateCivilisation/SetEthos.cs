using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjectAttributes;
using ProceduralWorldGeneration.Generator;

namespace ProceduralWorldGeneration.MythActions.CreateCivilisation
{
    class SetEthos : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            int total_value_spent = 0;
            foreach (CivilisationEthos ethos in taker.CreatedCivilisation.Ethos)
            {
                total_value_spent += ethos.Value;
            }

            if (total_value_spent <= 8)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            CivilisationEthos temp = CreationMythState.MythObjectData.Ethoses[ConfigValues.RandomGenerator.Next(CreationMythState.MythObjectData.Ethoses.Count)];
            
            foreach (CivilisationEthos ethos in taker.CreatedCivilisation.Ethos)
            {
                if (temp.Tag == ethos.Opposite)
                    return;

                if (temp.Tag == ethos.Tag)
                {
                    ethos.Value += 1;
                    return;
                }
                    
            }

            temp.Value = ConfigValues.RandomGenerator.Next(1, 5);
            taker.CreatedCivilisation.Ethos.Add(temp);

        }
    }
}
