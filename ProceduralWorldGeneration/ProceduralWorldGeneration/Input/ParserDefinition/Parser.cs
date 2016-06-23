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

            while (current_token != tokens.Last)
            {
                // At the end of a file it goes back to the root of the tree.
                if (current_token.Value.Type == "(end)")
                {
                    current_tree_node = ExpressionTreeRoot;
                    if (current_token.Next != null)
                    {
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
                    Expression temp_expression = new Expression();
                    temp_expression.ExpressionType = ExpressionTypes.List; // most top level variables are lists.
                    temp_expression.ExpressionValue = current_token.Value.Value; // the value is the name of the variable.
                    current_tree_node.AddChild(temp_expression);

                    if (current_token.Next.Value.Type == "ASSIGNMENT")
                    {
                        // selects the next token when an assignment is encountered after the variable. (this should always be the case)
                        current_token = current_token.Next;

                        if (current_token.Next.Value.Type == "OPENING_CURLY_BRACES")
                        {
                            // The opening braces indicate that there is several elements to be added. So the last created child is made current_tree_node.
                            current_tree_node = current_tree_node.GetLastChild();
                            current_token = current_token.Next.Next;

                            if (current_token.Next.Value.Type == "STRING")
                            {
                                // Add strings until there are no more. This means there is a list of strings.
                                while (current_token.Value.Type == "STRING")
                                {
                                    temp_expression = new Expression();
                                    temp_expression.ExpressionType = ExpressionTypes.String;
                                    temp_expression.ExpressionValue = current_token.Value.Value;

                                    current_tree_node.AddChild(temp_expression);

                                    current_token = current_token.Next;
                                }

                                current_tree_node.Value.ExpressionType = ExpressionTypes.List;
                                current_token = current_token.Next;
                            }
                        }
                        else if (current_token.Next.Value.Type == "STRING")
                        {
                            // A direct variable is named variable and assigned its value as an only child.
                            temp_expression = new Expression();
                            temp_expression.ExpressionType = ExpressionTypes.String;
                            temp_expression.ExpressionValue = current_token.Next.Value.Value;
                            current_tree_node.GetLastChild().AddChild(temp_expression);
                            // the parent of a string literal is a variable
                            current_tree_node.GetLastChild().Value.ExpressionType = ExpressionTypes.Variable;
                            // the parent of variables is always a class and not a list
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
        Integer
    }
}
