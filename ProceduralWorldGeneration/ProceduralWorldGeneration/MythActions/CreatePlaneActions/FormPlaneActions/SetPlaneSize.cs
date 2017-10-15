using ProceduralWorldGeneration.Attributes;
using ProceduralWorldGeneration.Main;


namespace ProceduralWorldGeneration.MythActions.CreatePlaneActions.FormPlaneActions
{
    abstract class SetPlaneSize : MythAction
    {

        protected PlaneSize SearchSize(string tag)
        {
            foreach (PlaneSize p in Program.DataLoadHandler.PlaneSizes)
                if (p.Tag == tag)
                    return p;
            return null;
        }
    }
}
