using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;

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

        private bool _has_created_defined_ethereal_plane = false;
        private bool _has_created_astral_plane = false;

        private int _deities_created = 0;
        private int _planes_created = 0;

        public override void takeAction(CreationMyth creation_myth, int current_year)
        {
            // Plane Creation Preparation
            int plane_creation_chance = calculatePlaneCreationChance();
            int plane_action_point_cost = calculatePlaneActionPointCost(current_year);

            // Deity Creation Preparation
            int deity_creation_chance = calculateDeityCreationChance();
            int deity_action_point_cost = calculateDeityActionPointCost(current_year);

            if (_action_points >= plane_action_point_cost)
            {
                createPlane(creation_myth, current_year, plane_action_point_cost);
            }

        }


        private void createPlane(CreationMyth creation_myth, int current_year, int plane_action_point_cost)
        {
            // Always first add the core world
            if (creation_myth.Planes.Count == 0)
            {
                addDefinedPlane("The Core World", creation_myth);
                _action_points = _action_points - plane_action_point_cost;
                return;
            }
            // Once the core world is added, the primordial powers add their respective ethereal planes to the core world.
            if (Name == "Light" && !_has_created_defined_ethereal_plane)
            {
                addDefinedPlane("Plane of Light", creation_myth);
                _action_points = _action_points - plane_action_point_cost;
                _has_created_defined_ethereal_plane = true;
                return;
            }
            if (Name == "Darkness" && !_has_created_defined_ethereal_plane)
            {
                addDefinedPlane("Shadow Plane", creation_myth);
                _action_points = _action_points - plane_action_point_cost;
                _has_created_defined_ethereal_plane = true;
                return;
            }
            if (Name == "Chaos" && !_has_created_defined_ethereal_plane)
            {
                addDefinedPlane("Plane of Entropy", creation_myth);
                _action_points = _action_points - plane_action_point_cost;
                _has_created_defined_ethereal_plane = true;
                return;
            }
            if (Name == "Order" && !_has_created_defined_ethereal_plane)
            {
                addDefinedPlane("Plane of Harmony", creation_myth);
                _action_points = _action_points - plane_action_point_cost;
                _has_created_defined_ethereal_plane = true;
                return;
            }
            // After there is a 40% chance to add the astral plane.
            if (ConfigValues.RandomGenerator.Next(100) < 40 && !_has_created_astral_plane)
            {
                addDefinedPlane("Astral Plane", creation_myth);
                _action_points = _action_points - plane_action_point_cost;
                _has_created_astral_plane = true;
                return;
            }

            // Once these are created random planes are added.
            createRandomPlane(creation_myth, current_year, plane_action_point_cost);

        }

        private void addDefinedPlane(string name, CreationMyth creation_myth)
        {
            foreach (Plane p in creation_myth.MythObjectData.DefinedPlanes)
            {
                if (p.Name == name)
                {
                    p.Creator = this;
                    p.connectPlane(creation_myth.Planes);
                    creation_myth.Planes.Add(p);
                    creation_myth.MythObjects.Add(p);
                    creation_myth.MythObjectData.DefinedPlanes.Remove(p);
                    creation_myth.Logger.updateLog(p, "CREATED");
                    break;
                }
            }
        }

        private void createRandomPlane(CreationMyth creation_myth, int current_year, int plane_action_point_cost)
        {
            Plane plane = new Plane();

            plane.PlaneType = creation_myth.MythObjectData.PlaneTypes[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.PlaneTypes.Count)];
            plane.Creator = this;

            if (plane.PlaneType == "material")
            {
                plane.PlaneSize = creation_myth.MythObjectData.PlaneSizes[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.PlaneSizes.Count)];
                plane.Name = plane.PlaneSize + " world";
            }
            else if (plane.PlaneType == "ethereal")
            {
                plane.PlaneSize = "pocket";
                plane.PlaneElement = creation_myth.MythObjectData.PlaneElements[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.PlaneElements.Count)];
                
            }
            else if (plane.PlaneType == "elemental")
            {
                plane.PlaneSize = creation_myth.MythObjectData.PlaneSizes[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.PlaneSizes.Count)];
                plane.PlaneElement = creation_myth.MythObjectData.PlaneElements[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.PlaneElements.Count)];
                plane.Name = plane.PlaneSize + " world of " + plane.PlaneElement;
            }

            plane.connectPlane(creation_myth.Planes);

            if (plane.PlaneType == "ethereal")
            {
                plane.Name = "ethereal " + plane.PlaneElement + " plane of \"" + plane.NeighbourPlanes[0].Name + "\"";
            }

            // add new plane to the creation myth and the log
            creation_myth.Planes.Add(plane);
            creation_myth.MythObjects.Add(plane);
            creation_myth.Logger.updateLog(plane, "CREATED");
            this.ActionPoints = ActionPoints - plane_action_point_cost;
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
            return _base_plane_action_point_cost + (current_year / 2);
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

        public override string ToString()
        {
            return Name + "          { Opposing : " + (Opposing == null ? "NONE" : Opposing) + " ; ActionPoints: " + ActionPoints + " }";
        }
    }
}
