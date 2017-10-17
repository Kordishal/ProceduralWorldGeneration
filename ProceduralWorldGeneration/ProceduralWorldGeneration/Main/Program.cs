using ProceduralWorldGeneration.DataLoader;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using ProceduralWorldGeneration.Utility;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProceduralWorldGeneration.Main
{
    /// <summary>
    /// Main starting point of the program.
    /// </summary>
    class Program
    {
        static private MythCreator _creation_myth_generator;

        static public DataLoadHandler DataLoadHandler { get; set; }
        static public GenerateCosmology CosmologyGenerator { get; set; }
        static public DebugConsole Debugger { get; set; }

        /// <summary>
        /// Global config values for the application. Defined before first start.
        /// </summary>
        static public ConfigValues GeneratorConfigurations { get; set; }

        static public void StartCreationLoop()
        {
            CosmologyGenerator.GeneratePrimordialForces();
            CosmologyGenerator.GenerateCreationString();
            //_creation_myth_generator.UniverseCreation();
        }

        static public void Initialise(UserInterfaceData user)
        {
            CosmologyGenerator = new GenerateCosmology(10000000);
            //_creation_myth_generator = new MythCreator();
            //_creation_myth_generator.Initialise(user);
        }

        static public void InitialiseData()
        {
            DataLoadHandler = new DataLoadHandler();
            DataLoadHandler.ReadDataFiles();
        }

        static Program()
        {
            GeneratorConfigurations = new ConfigValues();
            Debugger = new DebugConsole { DebugMessagesList = new List<string> { "New Beginnings!\n" } };
        }
    }
}
