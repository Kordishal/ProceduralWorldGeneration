using System.Linq;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Attributes;
using ProceduralWorldGeneration.Main;

namespace ProceduralWorldGeneration.MythActions.CreateCivilisation
{
    class SetEthos : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            int total_value_spent = 0;
            foreach (CivilizationEthos ethos in taker.CreatedCivilisation.Ethos)
            {
                total_value_spent += ethos.Strength;
            }

            if (total_value_spent <= 8)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            CivilizationEthos temp = Program.DataLoadHandler.CivilizationEthos[ConfigValues.Random.Next(Program.DataLoadHandler.CivilizationEthos.Count)];
            
            foreach (CivilizationEthos ethos in taker.CreatedCivilisation.Ethos)
            {
                if (temp.Tag == ethos.Opposite)
                    return;

                if (temp.Tag == ethos.Tag)
                {
                    ethos.Strength += 1;
                    return;
                }
                    
            }

            temp.Strength = ConfigValues.Random.Next(1, 5);
            taker.CreatedCivilisation.Ethos.Add(temp);

        }
    }
}
