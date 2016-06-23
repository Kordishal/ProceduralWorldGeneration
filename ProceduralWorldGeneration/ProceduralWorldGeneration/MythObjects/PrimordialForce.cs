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
    class PrimordialForce : ActionableBaseMythObject
    {
        public static string TYPE = "PrimordialForce";

        private int _spawn_weight;
        public int SpawnWeight
        {
            get
            {
                return _spawn_weight;
            }
            set
            {
                if (_spawn_weight != value)
                {
                    _spawn_weight = value;
                    base.NotifyPropertyChanged("SpawnWeight");
                }
            }
        }

        private string _opposing;
        public string Opposing
        {
            get
            {
                return _opposing;
            }
            set
            {
                if (_opposing != value)
                {
                    _opposing = value;
                    base.NotifyPropertyChanged("Opposing");
                }
            }
        }

        public PrimordialForce() : base()
        {
            base.Type = TYPE;
        }


        private int _base_deity_action_point_cost = 5;
        private int _base_plane_action_point_cost = 20;

        private int _base_deity_creation_chance = 50;
        private int _base_plane_creation_chance = 100;

        private int _deities_created = 0;
        private int _planes_created = 0;

        public override void takeAction(CreationMyth creation_myth, int current_year, Random rnd)
        {
            // Plane Creation Preparation
            int plane_creation_chance = calculatePlaneCreationChance(); 
            int plane_action_point_cost = calculatePlaneActionPointCost(current_year);

            // Deity Creation Preparation
            int deity_creation_chance = calculateDeityCreationChance();
            int deity_action_point_cost = calculateDeityActionPointCost(current_year);

            int total_creation_chance = deity_creation_chance + plane_creation_chance;

            int die_value = rnd.Next(total_creation_chance);

            // chance to create a plane
            if (die_value < plane_creation_chance)
            {

            }
            // chance to create a deity
            else if (die_value < deity_creation_chance + plane_creation_chance)
            {

            }




        }


        private void createPlane(CreationMyth creation_myth, int current_year, Random rnd)
        {

        }

        private int calculatePlaneCreationChance()
        {
            if (_planes_created == 0)
            {
                return _base_plane_creation_chance;
            }
            else
            {
                return _base_plane_creation_chance / _planes_created;
            }
        }
        private int calculatePlaneActionPointCost(int current_year)
        {
            return _base_plane_action_point_cost + ((current_year * 2) / 10);
        }

        private int calculateDeityCreationChance()
        {
            if (_deities_created == 0)
            {
                return _base_deity_creation_chance;
            }
            else
            {
                return _base_deity_creation_chance / (_deities_created < 10 ? 0 : _deities_created - 10);
            }
        }
        private int calculateDeityActionPointCost(int current_year)
        {
            return _base_deity_action_point_cost + ((current_year * 2) / 10);
        }
    }
}
