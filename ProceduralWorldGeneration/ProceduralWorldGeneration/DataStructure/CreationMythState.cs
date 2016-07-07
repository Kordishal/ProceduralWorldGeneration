using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Input;
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
    public class CreationMythState : INotifyPropertyChanged
    {
        private string _creation_string;
        public string CreationString
        {
            get
            {
                return _creation_string;
            }
            set
            {
                if (_creation_string != value)
                {
                    _creation_string = value;
                    this.NotifyPropertyChanged("CreationString");
                }
            }
        }

        private Tree<CreationTreeNode> _creation_tree;
        public Tree<CreationTreeNode> CreationTree
        {
            get
            {
                return _creation_tree;
            }
            set
            {
                if (_creation_tree != value)
                {
                    _creation_tree = value;
                    this.NotifyPropertyChanged("CreationTree");
                }
            }
        }

        private MythObjectData _myth_object_data;
        public MythObjectData MythObjectData
        {
            get
            {
                return _myth_object_data;
            }
            set
            {
                if (_myth_object_data != value)
                {
                    _myth_object_data = value;
                    this.NotifyPropertyChanged("MythObjectData");
                }
            }
        }

        private ObservableCollection<BaseMythObject> _myth_objects;
        public ObservableCollection<BaseMythObject> MythObjects
        {
            get
            {
                return _myth_objects;
            }
            set
            {
                if (_myth_objects != value)
                {
                    _myth_objects = value;
                    this.NotifyPropertyChanged("MythObjects");
                }
            }
        }

        private List<PrimordialForce> _primordial_forces;
        public List<PrimordialForce> PrimordialForces
        {
            get
            {
                return _primordial_forces;
            }
            set
            {
                if (_primordial_forces != value)
                {
                    _primordial_forces = value;
                    this.NotifyPropertyChanged("PrimordialForces");
                }
            }
        }

        private List<Plane> _planes;
        public List<Plane> Planes
        {
            get
            {
                return _planes;
            }
            set
            {
                if (_planes != value)
                {
                    _planes = value;
                    this.NotifyPropertyChanged("Planes");
                }
            }
        }

        private List<Deity> _deities;
        public List<Deity> Deities
        {
            get
            {
                return _deities;
            }
            set
            {
                if (_deities != value)
                {
                    _deities = value;
                    this.NotifyPropertyChanged("Deities");
                }
            }
        }

        private Queue<IActionTaker> _actionable_myth_objects;
        public Queue<IActionTaker> ActionableMythObjects
        {
            get
            {
                return _actionable_myth_objects;
            }
            set
            {
                if (_actionable_myth_objects != value)
                {
                    _actionable_myth_objects = value;
                    this.NotifyPropertyChanged("ActionableMythObjects");
                }
            }
        }

        public CreationMythState()
        {
            MythObjects = new ObservableCollection<BaseMythObject>();
            PrimordialForces = new List<PrimordialForce>();
            Planes = new List<Plane>();
            ActionableMythObjects = new Queue<IActionTaker>();
            _deities = new List<Deity>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
