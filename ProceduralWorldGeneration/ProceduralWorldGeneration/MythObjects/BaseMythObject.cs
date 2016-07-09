using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythObjects
{
    public class BaseMythObject : INotifyPropertyChanged
    {
        static int _identifier_seed = 0;

        private string _tag;
        public string Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                if (value != _tag)
                {
                    _tag = value;
                    this.NotifyPropertyChanged("Tag");
                }
            }
        }

        private int _identifier;
        public int Identifier
        {
            get
            {
                return _identifier;
            }
            set
            {
                if (value != _identifier)
                {
                    _identifier = value;
                    this.NotifyPropertyChanged("Identifier");
                }
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

        private BaseMythObject _creator;
        public BaseMythObject Creator
        {
            get
            {
                return _creator;
            }
            set
            {
                if (_creator != value)
                {
                    _creator = value;
                    NotifyPropertyChanged("Creator");
                }
            }
        }

        public BaseMythObject(string tag = Constants.SpecialTags.DEFAULT_TAG)
        {
            _identifier = _identifier_seed;
            _identifier_seed += 1;
            _tag = tag;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return "[" + Name + "|" + Identifier.ToString() + "]";
        }
    }
}
