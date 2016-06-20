using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Elements
{
    class Element : INotifyPropertyChanged
    {
        static private int _identifier_seed = 0;

        private int _identifier;
        public int Identifier
        {
            get
            {
                return _identifier;
            }
        }

        private int _group_id;
        public int GroupIdentifier
        {
            get
            {
                return _group_id;
            }
            set
            {
                if (value != _group_id)
                {
                    _group_id = value;
                    this.NotifyPropertyChanged("GroupIdentifier");
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

        private string _plural_name;
        public string PluralName
        {
            get
            {
                return _plural_name;
            }
            set
            {
                if (value != _plural_name)
                {
                    _plural_name = value;
                    this.NotifyPropertyChanged("PluralName");
                }
            }
        }

        private int _size;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (value != _size)
                {
                    _size = value;
                    this.NotifyPropertyChanged("Size");
                }
            }
        }

        private int _min_size;
        public int MinSize
        {
            get
            {
                return _min_size;
            }
            set
            {
                if (value != _min_size)
                {
                    _min_size = value;
                    this.NotifyPropertyChanged("MinSize");
                }
            }
        }

        private int _max_size;
        public int MaxSize
        {
            get
            {
                return _max_size;
            }
            set
            {
                if (value != _max_size)
                {
                    _max_size = value;
                    this.NotifyPropertyChanged("MaxSize");
                }
            }
        }

        private Element _parent_element;
        public Element ParentElement
        {
            get
            {
                return _parent_element;
            }
            set
            {
                if (value != _parent_element)
                {
                    _parent_element = value;
                    this.NotifyPropertyChanged("MemberElements");
                }
            }
        }


        private List<Element> _child_elements;
        public List<Element> ChildElements
        {
            get
            {
                return _child_elements;
            }
            set
            {
                if (value != _child_elements)
                {
                    _child_elements = value;
                    this.NotifyPropertyChanged("MemberElements");
                }
            }
        }

        public Element()
        {
            _identifier = _identifier_seed;
            _identifier_seed += 1;
            _child_elements = new List<Element>();
            _parent_element = null;
        }

        public Element(Element element)
        {
            _identifier = element._identifier;
            _group_id = element._group_id;
            _max_size = element._max_size;
            _min_size = element._min_size;
            _name = element._name;
            _plural_name = element._plural_name;

            _child_elements = new List<Element>();
            _parent_element = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


    }
}
