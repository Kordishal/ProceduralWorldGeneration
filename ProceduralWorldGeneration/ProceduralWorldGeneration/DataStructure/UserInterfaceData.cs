using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.DataStructure
{
    class UserInterfaceData : INotifyPropertyChanged
    {
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

        public void Update()
        {
            this.MythObjects = new ObservableCollection<BaseMythObject>(CreationMythState.MythObjects);
        }

        public UserInterfaceData()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
