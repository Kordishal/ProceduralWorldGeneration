using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.Input.ParserDefinition;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    class MythCreator : INotifyPropertyChanged
    {

        private MythObjectReader myth_object_reader;
        private Parser myth_object_parser;
        private MythObjectData generation_myth_objects;

        private ObservableCollection<BaseMythObject> _myth_objects;
        public ObservableCollection<BaseMythObject> MythObjects
        {
            get
            {
                return _myth_objects;
            }
            set
            {
                if (_myth_objects != value)
                {
                    _myth_objects = value;
                    this.NotifyPropertyChanged("MythObjects");
                }
            }
        }

        private List<PrimordialForce> _primordial_forces = new List<PrimordialForce>();

        private Random rnd;

        private int _current_year = 0;

        private int _end_year = 1000;

        public MythCreator()
        {
           
        }

        public void InitializeMythCreation(WorldGenerationConfig config)
        {
            rnd = new Random(config.RandomSeed.GetHashCode());
            myth_object_reader = new MythObjectReader();
            myth_object_reader.readMythObjects();
            myth_object_parser = new Parser();
            myth_object_parser.generateExpressionTree(myth_object_reader.Tokens);
            myth_object_parser.generateMythObjects();

            generation_myth_objects = myth_object_parser.MythObjects;

            MythObjects = new ObservableCollection<BaseMythObject>();
        }



        public void creationLoop()
        {
            createPrimordialPowers();


            while (_current_year < _end_year)
            {

                _current_year += 1;
            }

            // END OF CREATION
        }


        private void createPrimordialPowers()
        {
            List<PrimordialForce> all_primordial_forces = generation_myth_objects.PrimordialForces;
            int count = all_primordial_forces.Count;
            int total_weight = 0;

            // accumulate total weight
            foreach (PrimordialForce primordial_force in all_primordial_forces)
            {
                total_weight += primordial_force.SpawnWeight;
            }

            // pick first primordial power. There needs to be always at least one as otherwise nothing will be created.
            int chance = rnd.Next(total_weight);
            int current_weight = 0;
            foreach (PrimordialForce primordial_force in all_primordial_forces)
            {
                current_weight += primordial_force.SpawnWeight;
                if (chance < current_weight)
                {
                    _primordial_forces.Add(primordial_force);
                    break;
                }
            }

            // remove primordial force from list to not spawn it twice
            all_primordial_forces.Remove(_primordial_forces[0]);
            count = count - 1;

            // chance for a second primordial force.
            chance = rnd.Next(100);
            
            // 50% chance of an opposing force appearing.
            if (chance < 50 && _primordial_forces[0].Opposing != null)
            {
                _primordial_forces.Add(opposingForce(_primordial_forces[0]));
            }
            // 20% chance of any other force appearing.
            else if (chance < 70)
            {
                _primordial_forces.Add(all_primordial_forces[rnd.Next(count)]);
                all_primordial_forces.Remove(_primordial_forces[1]);
                count = count - 1;
                // 2% chance of a third force appearing
                if (chance < 52)
                {
                    _primordial_forces.Add(all_primordial_forces[rnd.Next(count)]);
                }
            }

            // Add them to the complete list for viewing
            foreach (PrimordialForce primordial_force in _primordial_forces)
            {
                MythObjects.Add(primordial_force);
            }

        }

        private PrimordialForce opposingForce(PrimordialForce primordial_force)
        {
            foreach (PrimordialForce current_primordial_force in generation_myth_objects.PrimordialForces)
            {
                if (current_primordial_force.Opposing == primordial_force.Name)
                {
                    return current_primordial_force;
                }
            }
            return null;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
