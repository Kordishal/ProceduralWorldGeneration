using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjectAttributes;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Parser;
using ProceduralWorldGeneration.Parser.Exceptions;
using ProceduralWorldGeneration.Parser.SyntaxTree;
using ProceduralWorldGeneration.Parser.Tokens;
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
                    temp_expression_1.ExpressionType = ExpressionTypes.Assignment; // most top level variables are lists. (may be overwritten by classes and string/integer/range variables)
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
                                current_tree_node.Value.ExpressionType = ExpressionTypes.Assignment;
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
                        // A variable after ASSIGNMENT
                        else if (current_token.Value.Type == "VARIABLE")
                        {
                            temp_expression_1 = new Expression();
                            temp_expression_1.ExpressionType = ExpressionTypes.Variable;
                            temp_expression_1.ExpressionValue = current_token.Value.Value;

                            current_tree_node.AddChild(temp_expression_1);

                            current_tree_node.Value.ExpressionType = ExpressionTypes.Variable;

                            current_tree_node.GetParent().Value.ExpressionType = ExpressionTypes.Assignment;

                            current_tree_node = current_tree_node.GetParent();

                            current_token = current_token.Next;
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
                            current_tree_node.GetParent().Value.ExpressionType = ExpressionTypes.Assignment;

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
                            current_tree_node.GetParent().Value.ExpressionType = ExpressionTypes.Assignment;

                            // Return current tree node to parent as there is nothing to add.
                            current_tree_node = current_tree_node.GetParent();

                            // Go to next token after "INTEGER"
                            current_token = current_token.Next;
                        }
                        // An boolean after Assignemnt
                        else if (current_token.Value.Type == "BOOLEAN")
                        {
                            // A direct variable is named variable and assigned its value as an only child.
                            temp_expression_1 = new Expression();
                            temp_expression_1.ExpressionType = ExpressionTypes.Boolean;
                            temp_expression_1.ExpressionValue = current_token.Value.Value;

                            // Add boolean to variable.
                            current_tree_node.AddChild(temp_expression_1);

                            // This is a variable as it only has a single value attached to it.
                            current_tree_node.Value.ExpressionType = ExpressionTypes.Variable;

                            // the parent of variables is always a class and not a list
                            current_tree_node.GetParent().Value.ExpressionType = ExpressionTypes.Assignment;

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
                                            current_tree_node.Value.ExpressionType = ExpressionTypes.Assignment;

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

            if (current_node.Value.ExpressionType == ExpressionTypes.Assignment)
            {
                if (parent_node.Value.ExpressionValue == "primordial_forces")
                {
                    PrimordialForce temp = new PrimordialForce(current_node.Value.ExpressionValue);
                    MythObjects.DefinedMythObjects.Add(temp);
                    MythObjects.PrimordialForces.Add(temp);
                }
                else if (parent_node.Value.ExpressionValue == "plane_sizes")
                {
                    PlaneSize temp = new PlaneSize(current_node.Value.ExpressionValue);
                    MythObjects.MythObjectAttributes.Add(temp);
                    MythObjects.PlaneSizes.Add(temp);
                }
                else if (parent_node.Value.ExpressionValue == "plane_types")
                {
                    PlaneType temp = new PlaneType(current_node.Value.ExpressionValue);
                    MythObjects.MythObjectAttributes.Add(temp);
                    MythObjects.PlaneTypes.Add(temp);
                }

            }

            if (current_node.Value.ExpressionType == ExpressionTypes.Variable)
            {
                if (parent_node.Value.ExpressionType == ExpressionTypes.Assignment)
                {
                    if (parent_node.GetParent().Value.ExpressionValue == "primordial_forces")
                    {
                        if (current_node.Value.ExpressionValue == "name")
                        {
                            MythObjects.PrimordialForces[MythObjects.PrimordialForces.Count - 1].Name = cutStringSigns(current_node.GetLastChild().Value.ExpressionValue);
                        }
                        if (current_node.Value.ExpressionValue == "opposing")
                        {
                            MythObjects.PrimordialForces[MythObjects.PrimordialForces.Count - 1].Opposing = (PrimordialForce)searchTag(current_node.GetLastChild().Value.ExpressionValue);
                        }
                        if (current_node.Value.ExpressionValue == "spawn_weight")
                        {
                            MythObjects.PrimordialForces[MythObjects.PrimordialForces.Count - 1].SpawnWeight = int.Parse(current_node.GetLastChild().Value.ExpressionValue);
                        }
                    }
                    else if (parent_node.GetParent().Value.ExpressionValue == "plane_sizes")
                    {
                        if (current_node.Value.ExpressionValue == "name")
                        {
                            MythObjects.PlaneSizes[MythObjects.PlaneSizes.Count - 1].Name = cutStringSigns(current_node.GetLastChild().Value.ExpressionValue);
                        }
                        else if (current_node.Value.ExpressionValue == "max_neighbours")
                        {
                            MythObjects.PlaneSizes[MythObjects.PlaneSizes.Count - 1].MaxNeighbourPlanes = int.Parse(current_node.GetLastChild().Value.ExpressionValue);
                        }
                    }  
                    else if (parent_node.GetParent().Value.ExpressionValue == "plane_types")
                    {
                        if (current_node.Value.ExpressionValue == "name")
                        {
                            MythObjects.PlaneTypes[MythObjects.PlaneTypes.Count - 1].Name = cutStringSigns(current_node.GetLastChild().Value.ExpressionValue);
                        }
                        else if (current_node.Value.ExpressionValue == "has_dominant_element")
                        {
                            MythObjects.PlaneTypes[MythObjects.PlaneTypes.Count - 1].hasDominantElement = bool.Parse(current_node.GetLastChild().Value.ExpressionValue);
                        }
                        else if (current_node.Value.ExpressionValue == "is_attached_to")
                        {
                            MythObjects.PlaneTypes[MythObjects.PlaneTypes.Count - 1].isAttachedTo = (PlaneType)searchAttributeTag(current_node.GetLastChild().Value.ExpressionValue);
                        }
                    }              
                }
            }


            if (current_node.Value.ExpressionType == ExpressionTypes.String)
            {        
                if (parent_node.Value.ExpressionType == ExpressionTypes.Assignment)
                {
                    if (parent_node.Value.ExpressionValue == "domains")
                    {
                        MythObjects.Domains.Add(cutStringSigns(current_node.Value.ExpressionValue));
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

        private BaseMythObject searchTag(string tag)
        {
            foreach (BaseMythObject mythobj in MythObjects.DefinedMythObjects)
            {
                if (mythobj.Tag == tag)
                {
                    return mythobj;
                }
            }

            return null;
        }

        private MythObjectAttribute searchAttributeTag(string tag)
        {
            foreach (MythObjectAttribute mythobj in MythObjects.MythObjectAttributes)
            {
                if (mythobj.Tag == tag)
                {
                    return mythobj;
                }
            }

            return null;
        }
    }
}
