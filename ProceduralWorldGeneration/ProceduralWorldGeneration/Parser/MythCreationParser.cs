using ProceduralWorldGeneration.Parser.SyntaxTree;
using ProceduralWorldGeneration.Parser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Parser
{
    class MythCreationParser
    {

        private MythObjectReader reader { get; set; }
        private List<Token> tokens { get; set; }

        public SyntaxTreeFiniteStateMachine<State> SyntaxTreeFSM { get; private set; }



        public MythCreationParser()
        {

        }

        public void Initialise()
        {
            reader = new MythObjectReader();
            reader.readMythObjects();


            SyntaxTreeFSM = new SyntaxTreeFiniteStateMachine<State>();
            initialiseSyntaxTreeFSM();
        }

        private void initialiseSyntaxTreeFSM()
        {

            SyntaxTreeFSM.AddTransition(State.VARIABLE, State.ASSIGNMENT, createAssignmentExpression);

            //SyntaxTreeFSM.AddTransition(State.ASSIGNMENT, State.FALSE, createBooleanVariable);
        }

        private void createAssignmentExpression(Tree<Expression> syntax_tree, Token token)
        {
            Expression expression = new Expression();
            expression.ExpressionType = ExpressionTypes.Assignment;
            expression.ExpressionValue = token.Value;

            // Add the assignment expression as a new child to the tree
            syntax_tree.CurrentNode.AddChild(expression);
            // go to said child to append the actual expression.
            syntax_tree.CurrentNode = syntax_tree.CurrentNode.GetLastChild();
        }

        private void createVariableExpression(Tree<Expression> syntax_tree, Token token)
        {
            Expression expression = new Expression();
            expression.ExpressionType = ExpressionTypes.Variable;
            expression.ExpressionValue = token.Value;

        }


        public void parsing()
        {
            foreach (Token t in tokens)
            {
                switch (t.Type)
                {
                    case "VARIABLE":
                        SyntaxTreeFSM.Advance(State.VARIABLE, t);
                        break;
                    case "(end)":
                        SyntaxTreeFSM.Advance(State.END_OF_FILE, t);
                        break;
                }
            }
        }
    }
}
