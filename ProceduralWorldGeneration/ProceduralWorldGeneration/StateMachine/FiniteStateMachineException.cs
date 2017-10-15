using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.StateMachine
{
    /// <summary>
    /// A custom exception for the FSM when encountering a invalid transition.
    /// Needs to be expanded to be useful.
    /// </summary>
    [Serializable]
    class FiniteStateMachineException : Exception
    {


        public override string Message
        {
            get
            {
                return "The FSM encountered an invalid transition";
            }
        }
    }
}
