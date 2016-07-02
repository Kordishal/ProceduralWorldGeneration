using ProceduralWorldGeneration.Parser.SyntaxTree;
using ProceduralWorldGeneration.Parser.Tokens;
using ProceduralWorldGeneration.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser
{
    class SyntaxTreeFiniteStateMachine<S> : FiniteStateMachine<S>
    {

        public delegate void StateHandler(Tree<Expression> current_tree_node, Token token);

        public Tree<Expression> SyntaxTree { get; set; }

        public SyntaxTreeFiniteStateMachine()
        {
            Expression root = new Expression();
            root.ExpressionType = ExpressionTypes.Root;
            root.ExpressionValue = "root";
            SyntaxTree = new Tree<Expression>(root);
        }

        public void Advance(S next_state, Token token)
        {
            StateTransition<S> temp_state_transition = new StateTransition<S>(currentState, next_state);

            System.Delegate temp_delegate;
            if (TransitionTable.TryGetValue(temp_state_transition, out temp_delegate))
            {
                if (temp_delegate != null)
                {
                    StateHandler call = temp_delegate as StateHandler;
                    call(SyntaxTree, token);
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




    public enum State
    {
        END_OF_FILE,
        VARIABLE,
        INTEGER,
        STRING,
        TRUE,
        FALSE,
        ASSIGNMENT,
        COMMA_SEPERATOR,
        OPENING_CURLY_BRACES,
        CLOSING_CURLY_BRACES,
        OPENING_SQUARE_BRACES,
        CLOSING_SQUARE_BRACES,
    }
}
