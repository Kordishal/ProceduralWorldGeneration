using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.MythActions;

namespace ProceduralWorldGeneration.MythObjects
{
    class PrimordialForce : ActionTakerMythObject
    {
        public static string TYPE = "PrimordialForce";

        public bool HasGatheredPower { get; set; }

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

        public override void addPossibleActions()
        {
            _possible_actions.Add(new Wait());
        }


        public PrimordialForce() : base()
        {
            base.Type = TYPE;
            HasGatheredPower = false;
        }


        private bool _has_created_defined_ethereal_plane = false;
        private bool _has_created_astral_plane = false;

        public override void takeAction(CreationMythState creation_myth, int current_year)
        {
            if (CurrentAction != null)
            {
                if (CurrentAction.getCurrentCooldown(creation_myth, this) <= 0)
                {
                    CurrentAction.Effect(creation_myth, this);
                    CurrentAction = null;
                }
                else
                {
                    CurrentAction.reduceCooldown(creation_myth, this);
                }
            }
            else
            {
                determineNextAction(creation_myth, this);
            }

        }


        private void createPlane(CreationMythState creation_myth, int current_year)
        {


            // Once these are created random planes are added.
            //createRandomPlane(creation_myth, current_year);

        }



        private void createRandomPlane(CreationMythState creation_myth, int current_year, int plane_action_point_cost)
        {
            creation_myth.MythObjectGenerator.PlaneGenerator.generatePlane(creation_myth, this);
        }


        private void createDeity(CreationMythState creation_myth, int current_year, int deity_action_point_cost)
        {
            creation_myth.MythObjectGenerator.DeityGenerator.generateDeity(creation_myth, this);
        }


        public override string ToString()
        {
            return Name + "          { Opposing : " + (Opposing == null ? "NONE" : Opposing) + " }";
        }
    }
}
