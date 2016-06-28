using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;

namespace ProceduralWorldGeneration.MythActions
{
    class GatherPower : MythAction
    {


        public override bool checkPrecondition(CreationMythState state, BaseMythObject taker)
        {
            if (taker.GetType() == typeof(PrimordialForce))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Effect(CreationMythState state, BaseMythObject taker)
        {
            (taker as PrimordialForce).HasGatheredPower = true;
        }



        public GatherPower()
        {
            Cooldown = 10;
            Duration = 5;
        }
    }
}
