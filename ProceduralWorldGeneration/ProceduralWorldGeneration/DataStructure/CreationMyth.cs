using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.DataStructure
{
    class CreationMyth : INotifyPropertyChanged
    {
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

        private Queue<IAction> _actionable_myth_objects;
        public Queue<IAction> ActionableMythObjects
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



        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
