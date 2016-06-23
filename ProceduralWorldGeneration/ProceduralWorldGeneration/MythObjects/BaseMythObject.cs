using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjects
{
    class BaseMythObject : INotifyPropertyChanged
    {
        static int _identifier_seed = 0;

        private int _identifier;
        public int Identifier
        {
            get
            {
                return _identifier;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (value != _type)
                {
                    _type = value;
                    this.NotifyPropertyChanged("Type");
                }
            }
        }

        public BaseMythObject()
        {
            _identifier = _identifier_seed;
            _identifier_seed += 1;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
