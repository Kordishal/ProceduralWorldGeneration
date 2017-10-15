using System.Collections.Generic;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions;
using ProceduralWorldGeneration.MythActions.General;
using ProceduralWorldGeneration.Attributes;

namespace ProceduralWorldGeneration.MythObjects
{
    public class Deity : ActionTakerMythObject
    {
        // The first domain is always the primary domain
        private List<Domain> _domains;
        public List<Domain> Domains
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
                    NotifyPropertyChanged("Domains");
                }
            }
        }

        // The personality has a big impact on how a deity acts.
        private DeityPersonality _personality;
        public DeityPersonality Personality
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
                    NotifyPropertyChanged("Personality");
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
                    NotifyPropertyChanged("Power");
                }
            }
        }


        public Deity(string tag = Constants.SpecialTags.DEFAULT_TAG) : base(tag)
        {
            _domains = new List<Domain>();
        }

        public override void takeAction(int current_year)
        {

        }

        protected override void setStateTransitions()
        {
            AddTransition(new InitialActionState(), new SetCreator());

            

            AddTransition(new SetName(), new AddToUniverse());

            AddTransition(new AddToUniverse(), new InitialActionState());
        }
    }
}
