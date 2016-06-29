using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions
{
    class CreateCorePlane : CreatePlane
    {

        public CreateCorePlane() : base()
        {

        }

        public override int getWeight(CreationMythState state, BaseMythObject taker)
        {
            if (state.Planes.Count == 0)
            {
                return 1000;
            }
            else
            {
                return 0;
            }
        }


        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            if (state.Planes.Count == 0)
            {
                return true;
            }


            return false;
        }



        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            determinePlaneType(100, 0, 0, state);

            addName();
            addCreatedPlaneToState(state);
        }
    }
}
