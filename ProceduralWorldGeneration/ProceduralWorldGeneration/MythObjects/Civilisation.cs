using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythObjects
{
    public class Civilisation : ActionTakerMythObject
    {


        private List<CivilisationEthos> _ethos;
        public List<CivilisationEthos> Ethos
        {
            get
            {
                return _ethos;
            }
            set
            {
                if (_ethos != value)
                {
                    _ethos = value;
                    base.NotifyPropertyChanged("Ethos");
                }
            }
        }



        public override void takeAction(int current_year)
        {
            throw new NotImplementedException();
        }

        protected override void setStateTransitions()
        {
            throw new NotImplementedException();
        }
    }
}
