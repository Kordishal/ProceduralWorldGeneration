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
                taker.CreatedPlane.Name = "Plane " + taker.CreatedPlane.Identifier;
            }
            else if (taker.CurrentGoal == ActionGoal.CreateDeity)
            {
                taker.CreadedDeity.Name = "Deity " + taker.CreadedDeity.Identifier;
            }
        }
    }
}
