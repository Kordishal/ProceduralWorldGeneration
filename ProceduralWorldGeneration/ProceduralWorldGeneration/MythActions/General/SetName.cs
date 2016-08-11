using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class SetName : MythAction
    {
        public override bool checkPrecondition(ActionTakerMythObject taker)
        {
            return true;
        }

        public override void Effect(ActionTakerMythObject taker)
        {
            if (taker.CurrentGoal == ActionGoal.CreatePlane)
            {
                taker.PlaneConstruction.Name = "Plane " + taker.PlaneConstruction.Identifier;
            }
            else if (taker.CurrentGoal == ActionGoal.CreateDeity)
            {
                taker.DeityCreation.Name = "Deity " + taker.DeityCreation.Identifier;
            }
        }
    }
}
