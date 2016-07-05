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
    class Deity : ActionTakerMythObject
    {
        private string _primary_domain;
        public string PrimaryDomain
        {
            get
            {
                return _primary_domain;
            }
            set
            {
                if (_primary_domain != value)
                {
                    _primary_domain = value;
                    base.NotifyPropertyChanged("PrimaryDomain");
                }
            }
        }


        public Deity(string tag = "default_tag") : base(tag)
        {
        }

        public override void takeAction(CreationMythState creation_myth, int current_year)
        {
        }

        public override void buildExistingActionsTree()
        {
            throw new NotImplementedException();
        }
    }
}
