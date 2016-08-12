using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythActions.CreateSapientSpeciesActions
{
    class AddUniqueTraits : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            int unique_categories = 0, traits_of_unique_categories = 0;
            foreach (TraitCategory category in CreationMythState.MythObjectData.TraitCategories)
            {
                if (category.isUnique)
                {
                    unique_categories += 1;
                    foreach (SpeciesTrait trait in taker.CreatedSapientSpecies.Traits)
                    {
                        if (trait.Category == category.Tag)
                        {
                            traits_of_unique_categories += 1;
                        }

                    }
                }
            }

            if (unique_categories == traits_of_unique_categories)
                return true;
            else
                return false;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            throw new NotImplementedException();
        }
    }
}
