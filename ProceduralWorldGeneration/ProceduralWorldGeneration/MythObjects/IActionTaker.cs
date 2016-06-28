using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.MythActions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjects
{
    interface IActionTaker
    {

        List<MythAction> PossibleActions { get; }

        MythAction CurrentAction { get; set; }

        /// <summary>
        /// The actions which can be taken by the entity.
        /// </summary>
        void takeAction(CreationMythState creation_myth, int current_year);

        void addPossibleActions();

        void determineNextAction(CreationMythState creation_myth);

    }
}
