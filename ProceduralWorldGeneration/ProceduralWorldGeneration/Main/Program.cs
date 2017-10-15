using ProceduralWorldGeneration.DataLoader;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
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

        /// <summary>
        /// Global config values for the application. Defined before first start.
        /// </summary>
        static public ConfigValues GeneratorConfigurations { get; set; }

        static public void StartCreationLoop()
        {
            _creation_myth_generator.creationLoop();
        }

        static public void Initialise(UserInterfaceData user)
        {
            _creation_myth_generator = new MythCreator();
            _creation_myth_generator.Initialise(user);
        }

        static public void InitialiseData()
        {
            DataLoadHandler = new DataLoadHandler();
            DataLoadHandler.ReadDataFiles();
        }

        static Program()
        {
            GeneratorConfigurations = new ConfigValues();
        }
    }
}
