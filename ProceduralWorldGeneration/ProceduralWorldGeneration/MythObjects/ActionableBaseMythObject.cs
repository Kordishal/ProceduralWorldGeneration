using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.Input;
using System.Collections.ObjectModel;
using ProceduralWorldGeneration.DataStructure;

namespace ProceduralWorldGeneration.MythObjects
{
    abstract class ActionableBaseMythObject : BaseMythObject, IAction
    {
        protected int _action_points;
        public int ActionPoints
        {
            get
            {
                return _action_points;
            }

            set
            {
                if (_action_points != value)
                {
                    _action_points = value;
                    NotifyPropertyChanged("ActionPoints");

                }
            }
        }

        protected int _min_action_regeneration;
        public int MinActionRegeneration
        {
            get
            {
                return _min_action_regeneration;
            }

            set
            {
                if (_min_action_regeneration != value)
                {
                    _min_action_regeneration = value;
                    NotifyPropertyChanged("MinActionRegeneration");

                }
            }
        }

        protected int _max_action_regeneration;
        public int MaxActionRegeneration
        {
            get
            {
                return _max_action_regeneration;
            }

            set
            {
                if (_max_action_regeneration != value)
                {
                    _max_action_regeneration = value;
                    NotifyPropertyChanged("MaxActionRegeneration");

                }
            }
        }

        protected int _action_regeneration_chance;
        public int ActionRegenrationChance
        {
            get
            {
                return _action_regeneration_chance;
            }

            set
            {
                if (_action_regeneration_chance != value)
                {
                    _action_regeneration_chance = value;
                    NotifyPropertyChanged("ActionRegenrationChance");

                }
            }
        }

        public void regenerateActionPoints(Random rnd)
        {
            if (rnd.Next(100) < _action_regeneration_chance)
            {
                ActionPoints += rnd.Next(_min_action_regeneration, _max_action_regeneration);
            }
        }

        public abstract void takeAction(CreationMyth creation_myth, int current_year, Random rnd);
    }
}
