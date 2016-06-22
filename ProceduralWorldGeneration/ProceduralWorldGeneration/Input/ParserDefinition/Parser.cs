using ProceduralWorldGeneration.Input.LexerDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Input.ParserDefinition
{
    class Parser
    {
        public Tree<Expression> ExpressionTreeRoot;


        public Parser()
        {
            Expression root_expression = new Expression();
            root_expression.ExpressionType = ExpressionTypes.Root;
            root_expression.ExpressionValue = "MYTH_OBJECTS";

            ExpressionTreeRoot = new Tree<Expression>(root_expression);
        }


        public void generateExpressionTree(LinkedList<Token> tokens)
        {
            TreeNode<Expression> current_tree_node = ExpressionTreeRoot;
            LinkedListNode<Token> current_token = tokens.First;

            while (current_token != tokens.Last)
            {
                if (current_token.Value.Type == "(end)")
                {
                    current_tree_node = ExpressionTreeRoot;
                    if (current_token.Next != null)
                    {
                        current_token = current_token.Next;
                    }
                    else
                    {
                        break;
                    }

                }
                else if (current_token.Value.Type == "VARIABLE")
                {
                    Expression temp_expression = new Expression();
                    temp_expression.ExpressionType = ExpressionTypes.Object;
                    temp_expression.ExpressionValue = current_token.Value.Value;
                    current_tree_node.AddChild(temp_expression);

                    if (current_token.Next.Value.Type == "ASSIGNMENT")
                    {
                        current_token = current_token.Next;

                        if (current_token.Next.Value.Type == "OPENING_CURLY_BRACES")
                        {
                            current_tree_node = current_tree_node.GetLastChild();
                            current_token = current_token.Next.Next;

                            if (current_token.Next.Value.Type == "STRING")
                            {
                                // Add strings until there are no more.
                                while (current_token.Next.Value.Type == "STRING")
                                {
                                    current_token = current_token.Next;

                                    temp_expression = new Expression();
                                    temp_expression.ExpressionType = ExpressionTypes.String;
                                    temp_expression.ExpressionValue = current_token.Value.Value;

                                    current_tree_node.AddChild(temp_expression);
                                }

                                current_tree_node.Value.ExpressionType = ExpressionTypes.List;
                                current_token = current_token.Next;
                            }
                        }
                        else if (current_token.Next.Value.Type == "STRING")
                        {
                            temp_expression = new Expression();
                            temp_expression.ExpressionType = ExpressionTypes.String;
                            temp_expression.ExpressionValue = current_token.Next.Value.Value;
                            current_tree_node.GetLastChild().AddChild(temp_expression);
                            current_tree_node.GetLastChild().Value.ExpressionType = ExpressionTypes.Variable;
                            current_tree_node.Value.ExpressionType = ExpressionTypes.Class;
                            current_token = current_token.Next.Next;
                        }
                    }
                }
                else if (current_token.Value.Type == "CLOSING_CURLY_BRACES")
                {
                    // Close current expression and return to the parent.
                    current_tree_node = current_tree_node.GetParent();
                    current_token = current_token.Next;
                }
            }

            Console.WriteLine("shit happens");
        }
    }

    class Expression
    {
        public ExpressionTypes ExpressionType { get; set; }
        public string ExpressionValue { get; set; }


        public override string ToString()
        {
            return ExpressionValue;
        }
    }


    enum ExpressionTypes
    {
        Root,
        Object,
        Class,
        List,
        Variable,
        String,
        Integer
    }
}
