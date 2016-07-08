using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions
{
    public class CreationState
    {
        //
        public bool isCreatingPlane { get; set; }

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
        public bool hasFirstConnection { get; set; }
        public bool isConnected { get; set; }
        public bool hasName { get; set; }
        public bool isAddedToUniverse { get; set; }

        //
        public bool isCreatingSapientSpecies { get; set; }

        public bool hasPlaneAndWorld { get; set; }
        public bool hasSpeciesType { get; set; }
        public bool hasPacificsmMilitarism { get; set; }
        public bool hasSpiritualismMaterialism { get; set; }
        public bool hasXenophobiaXenophilia { get; set; }
        public bool hasCollectivismIndividualism { get; set; }
        public bool hasEthos
        {
            get
            {
                return hasPacificsmMilitarism && hasSpiritualismMaterialism && hasXenophobiaXenophilia && hasCollectivismIndividualism;
            }
        }
        public bool hasHabitat { get; set; }
        public bool hasLifespan { get; set; }
        public bool hasPhysognomical { get; set; }
        public bool hasTraits
        {
            get
            {
                return hasHabitat && hasLifespan && hasPhysognomical;
            }
        }
        public bool hasInnatePower { get; set; }

        //
        public bool isCreatingDeity { get; set; }

        public bool hasPrimaryDomain { get; set; }
        public bool hasDomains { get; set; }
        public bool hasPersonality { get; set; }
        public bool hasPower { get; set; }

    }
}
