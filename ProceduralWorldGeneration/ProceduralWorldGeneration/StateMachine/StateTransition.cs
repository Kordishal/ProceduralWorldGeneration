using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.StateMachine
{
    /// <summary>
    /// Defines a possible transition from one state to another
    /// </summary>
    /// <typeparam name="S"> The type of the state</typeparam>
    class StateTransition<S> : IEquatable<StateTransition<S>>
    {
        public S InitialState { get; protected set; }
        public S EndState { get; protected set; }

        public StateTransition() { }
        public StateTransition(S init_state, S end_state)
        {
            InitialState = init_state;
            EndState = end_state;
        }

        public bool Equals(StateTransition<S> other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return InitialState.Equals(other.InitialState) && EndState.Equals(other.EndState);
        }

        public override int GetHashCode()
        {
            if ((InitialState == null || EndState == null))
                return 0;

            unchecked
            {
                int hash = 17;
                hash = hash * 23 + InitialState.GetHashCode();
                hash = hash * 23 + EndState.GetHashCode();
                return hash;
            }
        }
    }
}
