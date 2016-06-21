using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    class MythCreator : INotifyPropertyChanged
    {

        private Random rnd;

        private int _current_year = 0;

        private int _end_year = 1000;

        public MythCreator()
        {
           
        }

        public void InitializeMythCreation(WorldGenerationConfig config)
        {
            rnd = new Random(config.RandomSeed.GetHashCode());
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


        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
