using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Main
{
    /// <summary>
    /// Main starting point of the program.
    /// </summary>
    class Programm
    {
        static private MythCreator _creation_myth_generator;

        static public void startCreationLoop()
        {
            _creation_myth_generator.creationLoop();
        }

        static public void initialise(UserInterfaceData user)
        {
            _creation_myth_generator = new MythCreator();
            _creation_myth_generator.initialise(user);
        }
    }
}
