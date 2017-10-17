using ProceduralWorldGeneration.Utility;
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
                    NotifyPropertyChanged("Name");
                }
            }
        }

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
                    NotifyPropertyChanged("Tag");
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
                    NotifyPropertyChanged("Identifier");
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

        public List<string> Attributes { get; set; }
        public string AttributesDisplay { get { return Helpers.ListToString(Attributes); } set { } }

        public List<string> OppositeAttributes { get; set; }
        public string OppositeAttributesDisplay { get { return Helpers.ListToString(OppositeAttributes); } set { } }

        public BaseMythObject(string tag = Constants.SpecialTags.DEFAULT_TAG)
        {
            _identifier = _identifier_seed;
            _identifier_seed += 1;
            _tag = tag;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return "[" + Name + "|" + Identifier.ToString() + "]";
        }
    }
}
