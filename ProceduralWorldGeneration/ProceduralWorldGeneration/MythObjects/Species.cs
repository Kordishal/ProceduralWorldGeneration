using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;

namespace ProceduralWorldGeneration.MythObjects
{
    class Species : ActionTakerMythObject
    {

        static public string TYPE = "SPECIES";




        private bool _is_sentient;
        public bool IsSentient
        {
            get
            {
                return _is_sentient;
            }
            set
            {
                if (_is_sentient != value)
                {
                    _is_sentient = value;
                    this.NotifyPropertyChanged("IsSentient");
                }
            }
        }

        private bool _is_sapient;
        public bool IsSapient
        {
            get
            {
                return _is_sapient;
            }
            set
            {
                if (_is_sapient != value)
                {
                    _is_sapient = value;
                    this.NotifyPropertyChanged("IsSapient");
                }
            }
        }

        public Species()
        {


        }


        public override void takeAction(CreationMythState creation_myth, int current_year)
        {

        }

        public override void addPossibleActions()
        {
            throw new NotImplementedException();
        }
    }
}
