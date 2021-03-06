﻿using ProceduralWorldGeneration.MythObjects;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProceduralWorldGeneration.DataStructure
{
    /// <summary>
    /// All the created in universe stuff stored in a way to display within the UI.
    /// </summary>
    public class UserInterfaceData : INotifyPropertyChanged
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
                    NotifyPropertyChanged("MythObjects");
                }
            }
        }
            
        /// <summary>
        /// Updates the list of mythobjects with the list in from CreationMythState. It is a direct duplicate...
        /// </summary>
        public void Update()
        {
            MythObjects = new ObservableCollection<BaseMythObject>(CreationMythState.MythObjects);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
