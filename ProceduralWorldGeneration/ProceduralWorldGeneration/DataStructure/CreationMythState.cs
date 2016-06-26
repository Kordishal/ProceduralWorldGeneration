using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.MythObjects;
using ProceduralWorldGeneration.Output;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.DataStructure
{
    class CreationMythState : INotifyPropertyChanged
    {

        public CreationMythLogger Logger { get; set; }

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

        private List<BaseMythObject> _myth_objects;
        public List<BaseMythObject> MythObjects
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

        private MythObjectGenerators _myth_object_generator;
        public MythObjectGenerators MythObjectGenerator
        {
            get
            {
                return _myth_object_generator;
            }
            set
            {
                if (_myth_object_generator != value)
                {
                    _myth_object_generator = value;
                    this.NotifyPropertyChanged("MythObjectGenerator");
                }
            }
        }

        public CreationMythState()
        {
            Logger = new CreationMythLogger();
            MythObjects = new List<BaseMythObject>();
            PrimordialForces = new List<PrimordialForce>();
            Planes = new List<Plane>();
            ActionableMythObjects = new Queue<IActionTaker>();
            MythObjectGenerator = new MythObjectGenerators();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
