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
    public interface IActionTaker
    {

        List<MythAction> ValidActions { get; }

        MythAction CurrentAction { get; set; }

        /// <summary>
        /// The actions which can be taken by the entity.
        /// </summary>
        void takeAction(CreationMythState creation_myth, int current_year);

        void buildExistingActionsTree();

        void determineNextAction(CreationMythState creation_myth);

        void determineNextGoal(CreationMythState creation_myth);
    }
}
