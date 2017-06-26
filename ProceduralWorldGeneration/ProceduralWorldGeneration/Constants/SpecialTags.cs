using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Constants
{


    /// <summary>
    /// Special tags are used to identify specific myth objects. These will often have a specific predetermined purpose
    /// This purpose is established to create more sound universes and build them with certain constraints in place.
    /// </summary>
    class SpecialTags
    {
        // A tag which is applied to anthing that does not need a special tag.
        public const string DEFAULT_TAG = "default_tag";

        // The core plane is the first plane created. It is always a material plane where all the interesting stuff is supposed to happen
        public const string CORE_WORLD_TAG = "core_plane";

        // The travel dimension is an infinite elemental plane that connects all the other planes with eachother. 
        // This ensures that it is always possible to travel from any plane to any other plane.
        public const string TRAVEL_DIMENSION_TAG = "travel_dimension_plane";

        // Infinite planes do not have a beginning or an end. They will expand in all directions for eternity.
        public const string INFINITE_PLANE_SIZE = "infinite";


    }
}
