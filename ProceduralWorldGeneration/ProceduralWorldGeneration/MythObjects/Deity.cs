using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.DataStructure;

namespace ProceduralWorldGeneration.MythObjects
{
    public class Deity : ActionTakerMythObject
    {
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
                    base.NotifyPropertyChanged("Creator");
                }
            }
        }

        // The first domain is always the primary domain
        private List<string> _domains;
        public List<string> Domains
        {
            get
            {
                return _domains;
            }
            set
            {
                if (_domains != value)
                {
                    _domains = value;
                    base.NotifyPropertyChanged("Domains");
                }
            }
        }

        // The personality has a big impact on how a deity acts.
        private string _personality;
        public string Personality
        {
            get
            {
                return _personality;
            }
            set
            {
                if (_personality != value)
                {
                    _personality = value;
                    base.NotifyPropertyChanged("Personality");
                }
            }
        }

        // Trats describe the deity in greater detail.
        private List<string> _traits;
        public List<string> Traits
        {
            get
            {
                return _traits;
            }
            set
            {
                if (_traits != value)
                {
                    _traits = value;
                    base.NotifyPropertyChanged("Traits");
                }
            }
        }

        // The more power a deity has the more they can do.
        private int _power;
        public int Power
        {
            get
            {
                return _power;
            }
            set
            {
                if (_power != value)
                {
                    _power = value;
                    base.NotifyPropertyChanged("Power");
                }
            }
        }


        public Deity(string tag = "default_tag") : base(tag)
        {
            _domains = new List<string>();
            _traits = new List<string>();
        }

        public override void takeAction(CreationMythState creation_myth, int current_year)
        {


        }
    }
}
