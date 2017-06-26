using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Grammar;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Output;
using ProceduralWorldGeneration.Parser;
using ProceduralWorldGeneration.Parser.SyntaxTree;
using ProceduralWorldGeneration.SyntaxTreeTranslator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    /// <summary>
    /// Main Class which contains the main loop and setup.
    /// </summary>
    public class MythCreator
    {
        private UserInterfaceData _user;
        private MythCreationParser _parser;
        private Translator _translator;

        // initialize all the important values, parse the myth files and translate them into myth object data.
        public void initialise(UserInterfaceData user)
        {
            CreationMythState.initialise();

            _user = user;
            _user.Update();

            _parser = new MythCreationParser();
            _parser.initialise();
            _parser.parsing();

            _translator = new Translator(_parser.SyntaxTreeFSM.SyntaxTree);
            CreationMythState.MythObjectData = _translator.translate();
        }


        // Main generation loop
        public void creationLoop()
        {
            int _current_year = 0;
            int _end_year = 10000;
            int action_queue_count, counter;
            IActionTaker current_myth_object;

            CreationMythState.CreationString = createCreationString();
            // Generate the creation tree from the grammar rules.
            generateCreationTree();
            // Begin with the first primordial force
            CreationMythState.PrimordialForces.Add(CreationMythState.MythObjectData.PrimordialForces[0]);
            CreationMythState.ActionableMythObjects.Enqueue(CreationMythState.MythObjectData.PrimordialForces[0]);
            CreationMythState.MythObjects.Add(CreationMythState.PrimordialForces[0]);

            CreationMythState.CreationTree.TreeRoot.Children.First.Value.Value.MythObject = CreationMythState.PrimordialForces[0];

            CreationMythState.CreationTree.traverseTree(printCreationTree);

            // each tick is one year. Each myth object that can take actions can take one action per year at most.
            while (_current_year < _end_year)
            {
                // LOg the current year
                CreationMythLogger.updateLog(_current_year);
                // go through action queue once.
                counter = 0;
                action_queue_count = CreationMythState.ActionableMythObjects.Count;
                while (counter < action_queue_count)
                {
                    current_myth_object = CreationMythState.ActionableMythObjects.Dequeue();

                    current_myth_object.takeAction(_current_year);
        
                    CreationMythLogger.updateLog((BaseMythObject)current_myth_object, "UPDATE");

                    CreationMythState.ActionableMythObjects.Enqueue(current_myth_object);
                    counter = counter + 1;
                }

                //CreationMythLogger.Write();
                _current_year += 1;
            }


            CreationMythLogger.updateLog("END OF CREATION");
            CreationMythLogger.Write();
            CreationMythLogger.Clear();
            // Update the user interface data class.
            _user.Update();
            // END OF CREATION
        }

        /// <summary>
        /// Creates a string from the grammar rules.
        /// </summary>
        /// <returns>Returns a string of characters which represent the creation order.</returns>
        private string createCreationString()
        {
            MythCreationGrammar creation_grammar = new MythCreationGrammar();

            creation_grammar.repeatProduction(10);

            return creation_grammar.Result; 
        }

        // Parses the creation string and generates a tree from it. 
        // To better visualize how the parts interact with each other.
        // A child is always created by a parent or grand parent (the first which can take action).
        private void generateCreationTree()
        {
            Tree<CreationTreeNode> tree = new Tree<CreationTreeNode>(new CreationTreeNode("x"));
            TreeNode<CreationTreeNode> parent_node = null;
            TreeNode<CreationTreeNode> current_node = tree.TreeRoot;
            TreeNode<CreationTreeNode> last_created_force = null;
            TreeNode<CreationTreeNode> last_created_plane = null;
            TreeNode<CreationTreeNode> last_created_world = null;
            TreeNode<CreationTreeNode> last_created_deity = null;
            TreeNode<CreationTreeNode> last_created_pre_sentient = null;
            TreeNode<CreationTreeNode> last_created_sentient = null;
            TreeNode<CreationTreeNode> last_created_sapient = null;
            TreeNode<CreationTreeNode> last_created_mythical = null;
            TreeNode<CreationTreeNode> last_created_legendary = null;
            TreeNode<CreationTreeNode> last_created_civilisation = null;
            TreeNode<CreationTreeNode> last_created_nation = null;


            CreationMythState.CreationString = CreationMythState.CreationString.ToLower();

            foreach (char c in CreationMythState.CreationString)
            {

                // PRIMORDIAL FORCES
                // There can always only be a single primodrial force. 
                // Each repeatin f in the creation string is another action for the same force.
                if (c == 'f')
                {
                    if (current_node.Value.Character == "x")
                    {
                        current_node.AddChild(new CreationTreeNode("f"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_force = current_node;
                    }
                    else
                    {
                        current_node = last_created_force;
                    }
                }
                // PLANES
                // Planes are always created by premordial forces.
                else if (c == 'p')
                {
                    if (current_node.Value.Character == "f")
                    {
                        current_node.AddChild(new CreationTreeNode("p"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_plane = current_node;
                    }
                    else
                    {
                        current_node = last_created_plane;
                    }
                }
                else if (c == 'w')
                {
                    if (current_node.Value.Character == "p")
                    {
                        current_node.AddChild(new CreationTreeNode("w"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_world = current_node;
                    }
                    else
                    {
                        current_node = last_created_world;
                    }
                }
                else if (c == 'd')
                {
                    if (current_node.Value.Character == "w" || current_node.Value.Character == "f" || current_node.Value.Character == "v")
                    {
                        current_node.AddChild(new CreationTreeNode("d"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_deity = current_node;
                    }
                    else
                    {
                        current_node = last_created_deity;
                    }
                }
                else if (c == 'a')
                {
                    if (current_node.Value.Character == "d" || current_node.Value.Character == "p" || current_node.Value.Character == "e")
                    {
                        current_node.AddChild(new CreationTreeNode("a"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_sapient = current_node;
                    }
                    else
                    {
                        current_node = last_created_sapient;
                    }
                }
                else if (c == 'e')
                {
                    if (current_node.Value.Character == "s")
                    {
                        current_node.AddChild(new CreationTreeNode("e"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_sentient = current_node;
                    }
                    else
                    {
                        current_node = last_created_sentient;
                    }
                }
                else if (c == 's')
                {
                    if (current_node.Value.Character == "w")
                    {
                        current_node.AddChild(new CreationTreeNode("s"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_pre_sentient = current_node;
                    }
                    else
                    {
                        current_node = last_created_pre_sentient;
                    }
                }
                else if (c == 'c')
                {
                    if (current_node.Value.Character == "a" || current_node.Value.Character == "m")
                    {
                        current_node.AddChild(new CreationTreeNode("c"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_civilisation = current_node;
                    }
                    else
                    {
                        current_node = last_created_civilisation;
                    }
                }
                else if (c == 'n')
                {
                    if (current_node.Value.Character == "l" || current_node.Value.Character == "c")
                    {
                        current_node.AddChild(new CreationTreeNode("n"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_nation = current_node;
                    }
                    else
                    {
                        current_node = last_created_nation;
                    }
                }
                else if (c == 'm')
                {
                    if (current_node.Value.Character == "c" || current_node.Value.Character == "v")
                    {
                        current_node.AddChild(new CreationTreeNode("m"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_mythical = current_node;
                    }
                    else
                    {
                        current_node = last_created_mythical;
                    }
                }
                else if (c == 'l')
                {
                    if (current_node.Value.Character == "n" || current_node.Value.Character == "c")
                    {
                        current_node.AddChild(new CreationTreeNode("l"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_legendary = current_node;
                    }
                    else
                    {
                        current_node = last_created_legendary;
                    }
                }
                else if (c == 'v')
                {
                    if (current_node.Value.Character == "l")
                    {
                        current_node.AddChild(new CreationTreeNode("v"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                    }
                    else if (current_node.Value.Character == "m")
                    {
                        current_node.AddChild(new CreationTreeNode("v"));
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                    }
                }
            }

            CreationMythState.CreationTree = tree;      
        }

        private bool compareTreeNodeValue(TreeNode<string> node, string value)
        {
            if (node.Value == value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void printCreationTree(TreeNode<CreationTreeNode> current_node)
        {
            CreationMythLogger.updateTreeLog(current_node);
        }
    }

    /// <summary>
    /// A node of the creation tree stores all information on the object created and who created it.
    /// </summary>
    public class CreationTreeNode
    {
        public string Character { get; set; }
        public BaseMythObject MythObject { get; set; }
        public bool UnderConstruction { get; set; } // this object is being created by something.
        public ActionTakerMythObject Creator { get; set; }
        
        public CreationTreeNode(string character)
        {
            Character = character;
            MythObject = null;
            UnderConstruction = false;
        }

        public CreationTreeNode(BaseMythObject myth_object)
        {
            MythObject = myth_object;
            UnderConstruction = false;
        }

        public override string ToString()
        {
            if (MythObject == null)
            {
                return "[" + Character + "|NONE]";
            }
            else
            {
                return "[" + Character + "|" + MythObject.ToString() + "]";
            }
        }
    }
}
