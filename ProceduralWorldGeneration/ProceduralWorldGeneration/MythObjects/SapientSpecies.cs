using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjectAttributes;

namespace ProceduralWorldGeneration.MythObjects
{
    public class SapientSpecies : ActionTakerMythObject
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

        private int _innate_power;
        public int InnatePower
        {
            get
            {
                return _innate_power;
            }
            set
            {
                if (_innate_power != value)
                {
                    _innate_power = value;
                    base.NotifyPropertyChanged("InnatePower");
                }
            }
        }
        private Plane _native_plane;
        public Plane NativePlane
        {
            get
            {
                return _native_plane;
            }
            set
            {
                if (_native_plane != value)
                {
                    _native_plane = value;
                    base.NotifyPropertyChanged("NativePlane");
                }
            }
        }
        private World _homeworld;
        public World HomeWorld
        {
            get
            {
                return _homeworld;
            }
            set
            {
                if (_homeworld != value)
                {
                    _homeworld = value;
                    base.NotifyPropertyChanged("HomeWorld");
                }
            }
        }

        private SpeciesType _species_type;
        public SpeciesType SpeciesType
        {
            get
            {
                return _species_type;
            }
            set
            {
                if (_species_type != value)
                {
                    _species_type = value;
                    base.NotifyPropertyChanged("SpeciesType");
                }
            }
        }

        private List<SpeciesTrait> _traits;
        public List<SpeciesTrait> Traits
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

        private List<CivilisationEthos> _ethoi;
        public List<CivilisationEthos> Ethoi
        {
            get
            {
                return _ethoi;
            }
            set
            {
                if (_ethoi != value)
                {
                    _ethoi = value;
                    base.NotifyPropertyChanged("Ethoi");
                }
            }
        }

        public override void takeAction(int current_year)
        {
            throw new NotImplementedException();
        }
    }
}
