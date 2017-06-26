using ProceduralWorldGeneration.Parser.SyntaxTree;
using ProceduralWorldGeneration.Parser.Tokens;
using ProceduralWorldGeneration.StateMachine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser
{
    /// <summary>
    /// Implements the FSM to create a syntax tree as output.
    /// </summary>
    /// <typeparam name="S"></typeparam>
    class SyntaxTreeFiniteStateMachine<S> : FiniteStateMachine<S>
    {

        public delegate void StateHandler(Tree<Expression> current_tree_node, Token token);

        private Tree<Expression> _syntax_tree;
        public Tree<Expression> SyntaxTree
        {
            get
            {
                return _syntax_tree;
            }
            set
            {
                _syntax_tree = value;
            }
        }

        public SyntaxTreeFiniteStateMachine()
        {
            Expression root = new Expression();
            root.ExpressionType = ExpressionTypes.Root;
            root.ExpressionValue = "root";
            SyntaxTree = new Tree<Expression>(root);
            SyntaxTree.CurrentNode = SyntaxTree.TreeRoot;
        }

        public void Advance(S next_state, Token token)
        {
            StateTransition<S> temp_state_transition = new StateTransition<S>(currentState, next_state);

            Delegate temp_delegate;
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
        INITIAL_STATE,
        END_OF_FILE,
        VARIABLE,
        INTEGER,
        STRING,
        BOOLEAN,
        ASSIGNMENT,
        COMMA_SEPERATOR,
        OPENING_CURLY_BRACES,
        CLOSING_CURLY_BRACES,
        OPENING_SQUARE_BRACES,
        CLOSING_SQUARE_BRACES,
    }
}
