using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Attributes;

namespace ProceduralWorldGeneration.MythObjects
{
    public class Civilisation : ActionTakerMythObject
    {
        private List<CivilizationEthos> _ethos;
        public List<CivilizationEthos> Ethos
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
                    NotifyPropertyChanged("Ethos");
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
