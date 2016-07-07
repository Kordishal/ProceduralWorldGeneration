using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions
{
    class FormPlane : MythAction
    {

        public FormPlane() : base()
        {
            _is_primitve = false;
        }

        public override bool checkPrecondition(CreationMythState state, ActionTakerMythObject taker)
        {
            if (taker.CurrentCreationState.hasCreator)
            {
                if (!taker.CurrentCreationState.hasType || !taker.CurrentCreationState.hasSize || !taker.CurrentCreationState.hasElement)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public override void Effect(CreationMythState state, ActionTakerMythObject taker)
        {
            throw new NotImplementedException();
        }
    }
}
