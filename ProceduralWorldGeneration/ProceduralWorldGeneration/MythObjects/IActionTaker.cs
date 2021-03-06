﻿using ProceduralWorldGeneration.DataStructure;
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
        
        /// <summary>
        /// The actions which can be taken by the entity.
        /// </summary>
        void takeAction(int current_year);

        void determineNextAction();

        void determineNextGoal();
    }
}
