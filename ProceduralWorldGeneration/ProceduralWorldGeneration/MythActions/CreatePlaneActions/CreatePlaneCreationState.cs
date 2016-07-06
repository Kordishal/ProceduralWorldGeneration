using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    public class CreatePlaneCreationState
    {

        public bool hasCreator { get; set; }
        public bool hasType { get; set; }
        public bool hasSize { get; set; }
        public bool hasElement { get; set; }
        public bool formedPlane
        {
            get
            {
                return hasType && hasSize && hasElement;
            }
        }
        public bool isConnected { get; set; }
        public bool hasName { get; set; }
        public bool isAddedToUniverse { get; set; }

        public CreatePlaneCreationState()
        {
            hasCreator = false;
            hasType = false;
            hasSize = false;
            hasElement = false;
            isConnected = false;
            hasName = false;
            isAddedToUniverse = false;
        }
    }
}
