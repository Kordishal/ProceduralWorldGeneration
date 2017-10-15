using ProceduralWorldGeneration.Attributes;
using System.Collections.Generic;

namespace ProceduralWorldGeneration.MythObjects
{
    public class SapientSpecies : ActionTakerMythObject
    {
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
                    NotifyPropertyChanged("InnatePower");
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
                    NotifyPropertyChanged("NativePlane");
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
                    NotifyPropertyChanged("HomeWorld");
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
                    NotifyPropertyChanged("SpeciesType");
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
                    NotifyPropertyChanged("Traits");
                }
            }
        }

        public override void takeAction(int current_year)
        {
            
        }

        protected override void setStateTransitions()
        {
            
        }
    }
}
