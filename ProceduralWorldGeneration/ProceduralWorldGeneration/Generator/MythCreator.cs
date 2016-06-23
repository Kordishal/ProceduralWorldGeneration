using ProceduralWorldGeneration.Input;
using ProceduralWorldGeneration.Input.ParserDefinition;
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

        MythObjectReader myth_object_reader;
        Parser myth_object_parser;

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
