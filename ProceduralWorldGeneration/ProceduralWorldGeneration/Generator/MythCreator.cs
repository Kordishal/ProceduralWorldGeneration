using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Grammar;
using ProceduralWorldGeneration.Input;
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
    class MythCreator : INotifyPropertyChanged
    {
        private MythCreationParser _parser;
        private Translator _translator;

        private CreationMythState _creation_myth;
        public CreationMythState CreationMyths
        {
            get
            {
                return _creation_myth;
            }

            set
            {
                if (_creation_myth != value)
                {
                    _creation_myth = value;
                    NotifyPropertyChanged("CreationMyths");

                }
            }
        }

        public MythCreator()
        {
           
        }

        public void InitializeMythCreation()
        {
            _creation_myth = null;
            _creation_myth = new CreationMythState();

            _parser = new MythCreationParser();
            _parser.Initialise();
            _parser.parsing();

            _translator = new Translator(_parser.SyntaxTreeFSM.SyntaxTree);
            _creation_myth.MythObjectData = _translator.translate();


            _creation_myth.MythObjects = new ObservableCollection<BaseMythObject>();
            _creation_myth.ActionableMythObjects = new Queue<IActionTaker>();

            _creation_myth.PrimordialForces = new List<PrimordialForce>();
            _creation_myth.Planes = new List<Plane>();

            _creation_myth.CreationString = "";
        }



        public void creationLoop()
        {
            int _current_year = 0;
            int _end_year = 10000;
            int action_queue_count, counter;
            IActionTaker current_myth_object;

            CreationMyths.CreationString = createCreationString();

            generateCreationTree();

            _creation_myth.PrimordialForces.Add(_creation_myth.MythObjectData.PrimordialForces[0]);
            _creation_myth.ActionableMythObjects.Enqueue(_creation_myth.MythObjectData.PrimordialForces[0]);
            _creation_myth.MythObjects.Add(_creation_myth.PrimordialForces[0]);

            // each tick is one year. Each myth object that can take actions can take one action per year at most.
            while (_current_year < _end_year)
            {
                // LOg the current year
                _creation_myth.Logger.updateLog(_current_year);
                // go through action queue once.
                counter = 0;
                action_queue_count = _creation_myth.ActionableMythObjects.Count;
                while (counter < action_queue_count)
                {
                    current_myth_object = _creation_myth.ActionableMythObjects.Dequeue();

                    current_myth_object.takeAction(_creation_myth, _current_year);
        
                    _creation_myth.Logger.updateLog((BaseMythObject)current_myth_object, "UPDATE");

                    _creation_myth.ActionableMythObjects.Enqueue(current_myth_object);
                    counter = counter + 1;
                }

                _current_year += 1;
            }


            _creation_myth.Logger.updateLog("END OF CREATION");
            _creation_myth.Logger.Write();
            // END OF CREATION
        }

        private string createCreationString()
        {
            MythCreationGrammar creation_grammar = new MythCreationGrammar();

            creation_grammar.repeatProduction(10);

            return creation_grammar.Result; 
        }

        private void generateCreationTree()
        {
            Tree<string> tree = new Tree<string>("x");
            TreeNode<string> parent_node = null;
            TreeNode<string> current_node = tree.TreeRoot;
            TreeNode<string> last_created_force = null;
            TreeNode<string> last_created_plane = null;
            TreeNode<string> last_created_world = null;
            TreeNode<string> last_created_deity = null;
            TreeNode<string> last_created_pre_sentient = null;
            TreeNode<string> last_created_sentient = null;
            TreeNode<string> last_created_sapient = null;
            TreeNode<string> last_created_mythical = null;
            TreeNode<string> last_created_legendary = null;
            TreeNode<string> last_created_civilisation = null;
            TreeNode<string> last_created_nation = null;


            CreationMyths.CreationString = CreationMyths.CreationString.ToLower();

            foreach (char c in CreationMyths.CreationString)
            {
                if (c == 'f')
                {
                    if (current_node.Value == "x")
                    {
                        current_node.AddChild("f");
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                        last_created_force = current_node;
                    }
                    else
                    {
                        current_node = last_created_force;
                    }
                }
                else if (c == 'p')
                {
                    if (current_node.Value == "f")
                    {
                        current_node.AddChild("p");
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
                    if (current_node.Value == "p")
                    {
                        current_node.AddChild("w");
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
                    if (current_node.Value == "w" || current_node.Value == "f" || current_node.Value == "v")
                    {
                        current_node.AddChild("d");
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
                    if (current_node.Value == "d" || current_node.Value == "f" || current_node.Value == "e")
                    {
                        current_node.AddChild("a");
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
                    if (current_node.Value == "s")
                    {
                        current_node.AddChild("e");
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
                    if (current_node.Value == "w")
                    {
                        current_node.AddChild("s");
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
                    if (current_node.Value == "a" || current_node.Value == "m")
                    {
                        current_node.AddChild("c");
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
                    if (current_node.Value == "l" || current_node.Value == "c")
                    {
                        current_node.AddChild("n");
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
                    if (current_node.Value == "c" || current_node.Value == "v")
                    {
                        current_node.AddChild("m");
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
                    if (current_node.Value == "n" || current_node.Value == "c")
                    {
                        current_node.AddChild("l");
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
                    if (current_node.Value == "l")
                    {
                        current_node.AddChild("v");
                        parent_node = current_node;
                        current_node = current_node.GetLastChild();
                    }
                    else if (current_node.Value == "m")
                    {
                        current_node.AddChild("v");
                    }
                }
            }

            CreationMyths.CreationTree = tree;      
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



        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
