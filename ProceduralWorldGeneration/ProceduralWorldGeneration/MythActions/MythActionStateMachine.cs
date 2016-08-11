using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions
{
    class MythActionStateMachine<S> : FiniteStateMachine<S>
    {

        public delegate void StateHandler(ActionTakerMythObject taker);

        public S CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public void Advance(S next_state, ActionTakerMythObject taker)
        {
            StateTransition<S> temp_state_transition = new StateTransition<S>(currentState, next_state);

            System.Delegate temp_delegate;
            if (TransitionTable.TryGetValue(temp_state_transition, out temp_delegate))
            {
                if (temp_delegate != null)
                {
                    StateHandler call = temp_delegate as StateHandler;
                    call(taker);
                }

                previousState = currentState;
                currentState = next_state;
            }
            else
            {
                throw new FiniteStateMachineException();
            }
        }

        public void AddTransition(S initial_state, S end_state, StateHandler call)
        {
            StateTransition<S> temp_transition = new StateTransition<S>(initial_state, end_state);

            if (TransitionTable.ContainsKey(temp_transition))
            {
                return;
            }

            TransitionTable.Add(temp_transition, call);
        }


    }
}
