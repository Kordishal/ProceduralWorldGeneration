using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Output;
using ProceduralWorldGeneration.Parser;
using ProceduralWorldGeneration.Parser.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.DataStructure
{
    /// <summary>
    /// Contains all of the myth objects as a list or sorted into types.
    /// </summary>
    public class CreationMythState
    {
        static private string _creation_string;
        static public string CreationString
        {
            get
            {
                return _creation_string;
            }
            set
            {
                _creation_string = value;
            }
        }

        static private Tree<CreationTreeNode> _creation_tree;
        static public Tree<CreationTreeNode> CreationTree
        {
            get
            {
                return _creation_tree;
            }
            set
            {
                _creation_tree = value;
            }
        }

        static private MythObjectData _myth_object_data;
        static public MythObjectData MythObjectData
        {
            get
            {
                return _myth_object_data;
            }
            set
            {
                _myth_object_data = value;
            }
        }

        static private List<BaseMythObject> _myth_objects;
        static public List<BaseMythObject> MythObjects
        {
            get
            {
                return _myth_objects;
            }
            set
            {
                _myth_objects = value;
            }
        }

        static private List<PrimordialForce> _primordial_forces;
        static public List<PrimordialForce> PrimordialForces
        {
            get
            {
                return _primordial_forces;
            }
            set
            {
                _primordial_forces = value;
            }
        }

        static private List<Plane> _planes;
        static public List<Plane> Planes
        {
            get
            {
                return _planes;
            }
            set
            {
                _planes = value;
            }
        }

        static private List<Deity> _deities;
        static public List<Deity> Deities
        {
            get
            {
                return _deities;
            }
            set
            {
                _deities = value;
            }
        }

        // All the mythobjects which can take actions and create something of their own.
        static private Queue<IActionTaker> _actionable_myth_objects;
        static public Queue<IActionTaker> ActionableMythObjects
        {
            get
            {
                return _actionable_myth_objects;
            }
            set
            {
                _actionable_myth_objects = value;
            }
        }

        // Initialises all of the lists
        static private void initialise()
        {
            _myth_objects = new List<BaseMythObject>();
            _actionable_myth_objects = new Queue<IActionTaker>();
            _primordial_forces = new List<PrimordialForce>();
            _planes = new List<Plane>();
            _deities = new List<Deity>();

            _creation_string = "";
        }

        static CreationMythState()
        {
            initialise();
        }


        // SEARCH FUNCTIONS
    }
}
