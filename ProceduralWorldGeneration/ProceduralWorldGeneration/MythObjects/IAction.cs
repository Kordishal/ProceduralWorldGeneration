using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjects
{
    interface IAction
    {


        /// <summary>
        /// Action points represent an entities ability to do things. Each action will take a number of action points to perform and cann't be performed without them.
        /// </summary>
        int ActionPoints { get; set; }

        /// <summary>
        /// Each entitiy has a chance to regenerate a number of action points each tick. This is the smallest amount of action points it can regenerate.
        /// </summary>
        int MinActionRegeneration { get; set; }

        /// <summary>
        /// Each entitiy has a chance to regenerate a number of action points each tick. This is the highest amount of action points it can regenerate.
        /// </summary>
        int MaxActionRegeneration { get; set; }

        /// <summary>
        /// Each entitiy has a chance to regenerate a number of action points each tick. [0, 100]
        /// </summary>
        int ActionRegenrationChance { get; set; }


        /// <summary>
        /// The actions which can be taken by the entity.
        /// </summary>
        void takeAction(CreationMyth creation_myth, int current_year);

        /// <summary>
        /// In each tick the regeneration rate is messured.
        /// </summary>
        void regenerateActionPoints();
    }
}
