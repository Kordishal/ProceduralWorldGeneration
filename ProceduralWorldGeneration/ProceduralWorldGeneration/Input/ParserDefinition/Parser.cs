using ProceduralWorldGeneration.Input.LexerDefinition;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Input.ParserDefinition
{
    class Parser
    {
        public Tree<Expression> ExpressionTreeRoot { get; set; }
        public MythObjectData MythObjects { get; set; }


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
            Expression temp_expression_1, temp_expression_2;

            while (current_token != tokens.Last)
            {
                // At the end of a file it goes back to the root of the tree.
                if (current_token.Value.Type == "(end)")
                {
                    current_tree_node = ExpressionTreeRoot;
                    if (current_token.Next != null)
                    {
                        // Go to next token after the "(end)".
                        current_token = current_token.Next;
                    }
                    else
                    {
                        // loop ends if it was the las token
                        break;
                    }

                }
                else if (current_token.Value.Type == "VARIABLE")
                {
                    // when a variable is encountered it creates a new expression and adds it as a child to the current tree node.
                    temp_expression_1 = new Expression();
                    temp_expression_1.ExpressionType = ExpressionTypes.List; // most top level variables are lists. (may be overwritten by classes and string/integer/range variables)
                    temp_expression_1.ExpressionValue = current_token.Value.Value; // the value is the name of the variable.

                    // Add a child to current tree node
                    current_tree_node.AddChild(temp_expression_1);

                    // Go to next token after "VARIABLE".
                    current_token = current_token.Next;

                    // After a variable comes an assignment to assign the values after it.
                    if (current_token.Value.Type == "ASSIGNMENT")
                    {
                        // Goes to last added child: "VARIABLE"
                        current_tree_node = current_tree_node.GetLastChild();

                        // Go to next token after "ASSIGNMENT"
                        current_token = current_token.Next;

                        if (current_token.Value.Type == "OPENING_CURLY_BRACES")
                        {
                            // Go to next token after "OPENING_CURLY_BRACES"
                            current_token = current_token.Next;

                            if (current_token.Next.Value.Type == "STRING")
                            {
                                // Add strings until there are no more. This means there is a list of strings.
                                while (current_token.Value.Type == "STRING")
                                {
                                    // Create a new String Expression
                                    temp_expression_1 = new Expression();
                                    temp_expression_1.ExpressionType = ExpressionTypes.String;
                                    temp_expression_1.ExpressionValue = current_token.Value.Value;

                                    // Add String expression as a child.
                                    current_tree_node.AddChild(temp_expression_1);
                                    // goes to next token 
                                    current_token = current_token.Next;
                                }
                                // makes sure that the tree node is a list.
                                current_tree_node.Value.ExpressionType = ExpressionTypes.List;
                            }
                            else if (current_token.Value.Type == "VARIABLE")
                            {
                                // DO NOTHING AS THIS CASE WILL BE CAUTGH IN THE NEXT ITERATION
                            }
                            else
                            {
                                throw new ParserException(current_token.Value);
                            }
                        }
                        // A string after "ASSIGNMENT"
                        else if (current_token.Value.Type == "STRING")
                        {
                            // A direct variable is named variable and assigned its value as an only child.
                            temp_expression_1 = new Expression();
                            temp_expression_1.ExpressionType = ExpressionTypes.String;
                            temp_expression_1.ExpressionValue = current_token.Value.Value;

                            // Add string to variable.
                            current_tree_node.AddChild(temp_expression_1);

                            // This is a variable as it only has a a single string attached to it.
                            current_tree_node.Value.ExpressionType = ExpressionTypes.Variable;

                            // The parent of variables is always a class and not a list.
                            current_tree_node.GetParent().Value.ExpressionType = ExpressionTypes.Class;

                            // Return current tree node to parent as there is nothing to add
                            current_tree_node = current_tree_node.GetParent();

                            // Go to next token after "STRING"
                            current_token = current_token.Next;
                        }
                        // An integer after "ASSIGNMENT"
                        else if (current_token.Value.Type == "INTEGER")
                        {
                            // A direct variable is named variable and assigned its value as an only child.
                            temp_expression_1 = new Expression();
                            temp_expression_1.ExpressionType = ExpressionTypes.Integer;
                            temp_expression_1.ExpressionValue = current_token.Value.Value;

                            // Add integer to variable.
                            current_tree_node.AddChild(temp_expression_1);

                            // This is a variable as it only has a single value attached to it.
                            current_tree_node.Value.ExpressionType = ExpressionTypes.Variable;

                            // the parent of variables is always a class and not a list
                            current_tree_node.GetParent().Value.ExpressionType = ExpressionTypes.Class;

                            // Return current tree node to parent as there is nothing to add.
                            current_tree_node = current_tree_node.GetParent();

                            // Go to next token after "INTEGER"
                            current_token = current_token.Next;
                        }
                        // An [ after "ASSIGNMENT"
                        else if (current_token.Value.Type == "OPENING_SQUARE_BRACES")
                        {
                            // Go to next token after "OPENING_SQUARE_BRACES"
                            current_token = current_token.Next;

                            if (current_token.Value.Type == "INTEGER")
                            {
                                // Create the minimum value expression.
                                temp_expression_1 = new Expression();
                                temp_expression_1.ExpressionType = ExpressionTypes.Integer;
                                temp_expression_1.ExpressionValue = current_token.Value.Value;

                                // Go to next token after "INTEGER"
                                current_token = current_token.Next;

                                if (current_token.Value.Type == "COMMA_SEPARATOR")
                                {
                                    // Go to next token after "COMMA_SEPARATOR"
                                    current_token = current_token.Next;

                                    if (current_token.Value.Type == "INTEGER")
                                    {
                                        // Create the maximum value expression
                                        temp_expression_2 = new Expression();
                                        temp_expression_2.ExpressionType = ExpressionTypes.Integer;
                                        temp_expression_2.ExpressionValue = current_token.Value.Value;

                                        // Go to next token after "INTEGER"
                                        current_token = current_token.Next;
                                        if (current_token.Value.Type == "CLOSING_SQUARE_BRACES")
                                        {
                                            // Creates the range expression
                                            current_tree_node.Value.ExpressionType = ExpressionTypes.Range;
                                            current_tree_node.AddChild(temp_expression_1);
                                            current_tree_node.AddChild(temp_expression_2);

                                            // Return to parent tree node.
                                            current_tree_node = current_tree_node.GetParent();

                                            // parent tree node is always a class
                                            current_tree_node.Value.ExpressionType = ExpressionTypes.Class;

                                            // Go to next token after "CLOSING_SQUARE_BRACES"
                                            current_token = current_token.Next;
                                        }
                                        else
                                        {
                                            throw new ParserException(current_token.Value);
                                        }
                                    }
                                    else
                                    {
                                        throw new ParserException(current_token.Value);
                                    }
                                }
                                else
                                {
                                    throw new ParserException(current_token.Value);
                                }
                            }
                            else
                            {
                                throw new ParserException(current_token.Value);
                            }
                        }
                        else
                        {
                            throw new ParserException(current_token.Value);
                        }
                    }
                    else
                    {
                        throw new ParserException(current_token.Value);
                    }
                }
                else if (current_token.Value.Type == "CLOSING_CURLY_BRACES")
                {
                    // Close current expression and return to the parent.
                    current_tree_node = current_tree_node.GetParent();
                    current_token = current_token.Next;
                }
                else
                {
                    throw new ParserException(current_token.Value);
                }
            }
        }


        public void generateMythObjects()
        {
            MythObjects = new MythObjectData();
            traverseExpressionTree(ExpressionTreeRoot);
            Console.Write(true);
        }


        private void traverseExpressionTree(TreeNode<Expression> current_node)
        {
            TreeNode<Expression> parent_node = current_node.GetParent();

            if (current_node.Value.ExpressionType == ExpressionTypes.Class)
            {
                if (current_node.Value.ExpressionValue == "primordial_force")
                {
                    MythObjects.PrimordialForces.Add(new PrimordialForce());
                }
            }

            if (current_node.Value.ExpressionType == ExpressionTypes.Variable)
            {
                if (parent_node.Value.ExpressionType == ExpressionTypes.Class)
                {
                    if (parent_node.Value.ExpressionValue == "primordial_force")
                    {
                        if (current_node.Value.ExpressionValue == "name")
                        {
                            MythObjects.PrimordialForces[MythObjects.PrimordialForces.Count - 1].Name = cutStringSigns(current_node.GetLastChild().Value.ExpressionValue);
                        }
                        if (current_node.Value.ExpressionValue == "opposing")
                        {
                            MythObjects.PrimordialForces[MythObjects.PrimordialForces.Count - 1].Opposing = cutStringSigns(current_node.GetLastChild().Value.ExpressionValue);
                        }
                        if (current_node.Value.ExpressionValue == "spawn_weight")
                        {
                            MythObjects.PrimordialForces[MythObjects.PrimordialForces.Count - 1].SpawnWeight = int.Parse(current_node.GetLastChild().Value.ExpressionValue);
                        }
                    }
                }
            }


            if (current_node.Value.ExpressionType == ExpressionTypes.String)
            {        
                if (parent_node.Value.ExpressionType == ExpressionTypes.List)
                {
                    if (parent_node.Value.ExpressionValue == "domains")
                    {
                        MythObjects.Domains.Add(cutStringSigns(current_node.Value.ExpressionValue));
                    }
                    else if (parent_node.Value.ExpressionValue == "plane_types")
                    {
                        MythObjects.PlaneTypes.Add(cutStringSigns(current_node.Value.ExpressionValue));
                    }
                    else if (parent_node.Value.ExpressionValue == "plane_elements")
                    {
                        MythObjects.PlaneElements.Add(cutStringSigns(current_node.Value.ExpressionValue));
                    }
                    else if (parent_node.Value.ExpressionValue == "plane_sizes")
                    {
                        MythObjects.PlaneSizes.Add(cutStringSigns(current_node.Value.ExpressionValue));
                    }
                }
            }

            foreach (TreeNode<Expression> child in current_node.GetChildren())
            {
                traverseExpressionTree(child);
            }
        }


        private string cutStringSigns(string s)
        {
            return s.Substring(1, s.Length - 2);
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
        Class,
        List,
        Variable,
        String,
        Integer,
        Range,
    }
}
