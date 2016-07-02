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
            // Read the files and put them through the Lexer.
            reader = new MythObjectReader();
            reader.readMythObjects();

            // Get the tokens.
            tokens = reader.Tokens;

            // Initialize the Syntax tree
            SyntaxTreeFSM = new SyntaxTreeFiniteStateMachine<State>();
            initialiseSyntaxTreeFSM();
        }

        private void initialiseSyntaxTreeFSM()
        {
            // Set initial state
            SyntaxTreeFSM.Initialise(State.INITIAL_STATE);

            // Transition from inital state to first variable.
            SyntaxTreeFSM.AddTransition(State.INITIAL_STATE, State.VARIABLE, createVariableDefinitionExpression);    

            // ASSIGNEMENTS
            SyntaxTreeFSM.AddTransition(State.ASSIGNMENT, State.BOOLEAN, createBooleanAssignmentExpression);
            SyntaxTreeFSM.AddTransition(State.ASSIGNMENT, State.STRING, createStringAssignmentExpression);
            SyntaxTreeFSM.AddTransition(State.ASSIGNMENT, State.INTEGER, createIntegerAssignmentExpression);
            SyntaxTreeFSM.AddTransition(State.ASSIGNMENT, State.VARIABLE, createVariableAssignmentExpression);
            SyntaxTreeFSM.AddTransition(State.ASSIGNMENT, State.OPENING_CURLY_BRACES, doNothing);

            // Opening Cirly Braces
            SyntaxTreeFSM.AddTransition(State.OPENING_CURLY_BRACES, State.VARIABLE, createVariableDefinitionExpression);
            SyntaxTreeFSM.AddTransition(State.OPENING_CURLY_BRACES, State.STRING, createStringListAssignmentExpression);

            // Closing Curly braces
            SyntaxTreeFSM.AddTransition(State.CLOSING_CURLY_BRACES, State.END_OF_FILE, returnToRoot);
            SyntaxTreeFSM.AddTransition(State.CLOSING_CURLY_BRACES, State.CLOSING_CURLY_BRACES, returnToLastAssignment);
            SyntaxTreeFSM.AddTransition(State.CLOSING_CURLY_BRACES, State.VARIABLE, createVariableDefinitionExpression);

            // VARIABLES.
            SyntaxTreeFSM.AddTransition(State.VARIABLE, State.ASSIGNMENT, createAssignmentExpression);
            SyntaxTreeFSM.AddTransition(State.VARIABLE, State.CLOSING_CURLY_BRACES, returnToLastAssignment);
            SyntaxTreeFSM.AddTransition(State.VARIABLE, State.VARIABLE, createVariableDefinitionExpression);

            //BOOLEANS
            SyntaxTreeFSM.AddTransition(State.BOOLEAN, State.VARIABLE, createVariableDefinitionExpression);
            SyntaxTreeFSM.AddTransition(State.BOOLEAN, State.CLOSING_CURLY_BRACES, returnToLastAssignment);

            // INTEGERS
            SyntaxTreeFSM.AddTransition(State.INTEGER, State.VARIABLE, createVariableDefinitionExpression);
            SyntaxTreeFSM.AddTransition(State.INTEGER, State.CLOSING_CURLY_BRACES, returnToLastAssignment);

            // STRINGS
            SyntaxTreeFSM.AddTransition(State.STRING, State.VARIABLE, createVariableDefinitionExpression);
            SyntaxTreeFSM.AddTransition(State.STRING, State.CLOSING_CURLY_BRACES, returnToLastAssignment);
            SyntaxTreeFSM.AddTransition(State.STRING, State.STRING, createStringListAssignmentExpression);

            // END OF FILE
            SyntaxTreeFSM.AddTransition(State.END_OF_FILE, State.VARIABLE, createVariableDefinitionExpression);
        }

        private void doNothing(Tree<Expression> syntax_tree, Token token)
        {

        }

        private void returnToRoot(Tree<Expression> syntax_tree, Token token)
        {
            syntax_tree.CurrentNode = syntax_tree.TreeRoot;
        }

        private void createAssignmentExpression(Tree<Expression> syntax_tree, Token token)
        {
            // An assignemnt is always towards a variable. So one will always be defined already. And the current node is the node of this assignement.
            syntax_tree.CurrentNode.Value.ExpressionType = ExpressionTypes.Assignment;
            syntax_tree.CurrentNode.Value.ExpressionValue = "=";

        }

        private void createVariableDefinitionExpression(Tree<Expression> syntax_tree, Token token)
        {
            // A dummy expression. This will later become the assignement expression for this variable.
            Expression dummy_expression = new Expression();
            syntax_tree.CurrentNode.AddChild(dummy_expression);
            syntax_tree.CurrentNode = syntax_tree.CurrentNode.GetLastChild();

            // Create the expression for the Variable.
            Expression expression = new Expression();
            expression.ExpressionType = ExpressionTypes.Variable;
            expression.ExpressionValue = token.Value;

            // Add the variable expression as a new child to the tree
            syntax_tree.CurrentNode.AddChild(expression);
        }

        private void createVariableAssignmentExpression(Tree<Expression> syntax_tree, Token token)
        {
            // Create the expression for the Variable.
            Expression expression = new Expression();
            expression.ExpressionType = ExpressionTypes.Variable;
            expression.ExpressionValue = token.Value;

            // Add the variable expression as a new child to the tree
            syntax_tree.CurrentNode.AddChild(expression);

            // return to the last assignment:
            syntax_tree.CurrentNode = syntax_tree.CurrentNode.GetParent();
        }

        private void createStringAssignmentExpression(Tree<Expression> syntax_tree, Token token)
        {
            Expression expression = new Expression();
            expression.ExpressionType = ExpressionTypes.String;
            expression.ExpressionValue = token.Value;

            // Add the assignment expression as a new child to the tree
            syntax_tree.CurrentNode.AddChild(expression);

            // return to the last assignment:
            syntax_tree.CurrentNode = syntax_tree.CurrentNode.GetParent();
        }

        private void createIntegerAssignmentExpression(Tree<Expression> syntax_tree, Token token)
        {
            Expression expression = new Expression();
            expression.ExpressionType = ExpressionTypes.Integer;
            expression.ExpressionValue = token.Value;

            // Add the assignment expression as a new child to the tree
            syntax_tree.CurrentNode.AddChild(expression);

            // return to the last assignment:
            syntax_tree.CurrentNode = syntax_tree.CurrentNode.GetParent();
        }

        private void createBooleanAssignmentExpression(Tree<Expression> syntax_tree, Token token)
        {
            Expression expression = new Expression();
            expression.ExpressionType = ExpressionTypes.Boolean;
            expression.ExpressionValue = token.Value;

            // Add the assignment expression as a new child to the tree
            syntax_tree.CurrentNode.AddChild(expression);

            // return to the last assignment:
            syntax_tree.CurrentNode = syntax_tree.CurrentNode.GetParent();
        }

        private void createStringListAssignmentExpression(Tree<Expression> syntax_tree, Token token)
        {
            Expression expression = new Expression();
            expression.ExpressionType = ExpressionTypes.String;
            expression.ExpressionValue = token.Value;

            // Add the assignment expression as a new child to the tree
            syntax_tree.CurrentNode.AddChild(expression);
        }

        private void returnToLastAssignment(Tree<Expression> syntax_tree, Token token)
        {
            syntax_tree.CurrentNode = syntax_tree.CurrentNode.GetParent();
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
                    case "STRING":
                        SyntaxTreeFSM.Advance(State.STRING, t);
                        break;
                    case "INTEGER":
                        SyntaxTreeFSM.Advance(State.INTEGER, t);
                        break;
                    case "ASSIGNMENT":
                        SyntaxTreeFSM.Advance(State.ASSIGNMENT, t);
                        break;
                    case "BOOLEAN":
                        SyntaxTreeFSM.Advance(State.BOOLEAN, t);
                        break;
                    case "OPENING_CURLY_BRACES":
                        SyntaxTreeFSM.Advance(State.OPENING_CURLY_BRACES, t);
                        break;
                    case "CLOSING_CURLY_BRACES":
                        SyntaxTreeFSM.Advance(State.CLOSING_CURLY_BRACES, t);
                        break;
                    case "OPENING_SQUARE_BRACES":
                        SyntaxTreeFSM.Advance(State.OPENING_SQUARE_BRACES, t);
                        break;
                    case "CLOSING_SQUARE_BRACES":
                        SyntaxTreeFSM.Advance(State.CLOSING_SQUARE_BRACES, t);
                        break;
                    case "(end)":
                        SyntaxTreeFSM.Advance(State.END_OF_FILE, t);
                        break;
                }
            }
        }
    }
}
