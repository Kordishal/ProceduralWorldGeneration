using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Utility
{
    public class DebugConsole : INotifyPropertyChanged
    {
        public List<string> DebugMessagesList { get; set; }

        public string DebugMessages { get { return Helpers.ListToString(DebugMessagesList); } set { } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
