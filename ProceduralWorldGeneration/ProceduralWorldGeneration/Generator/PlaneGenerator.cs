using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.MythObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.Generator
{
    class PlaneGenerator
    {

        public Plane GeneratedPlane { get; set; }

        public PlaneGenerator()
        {


        }



        public void generatePlane(CreationMyth creation_myth, BaseMythObject creator)
        {
            GeneratedPlane = new Plane();

            GeneratedPlane.PlaneType = creation_myth.MythObjectData.PlaneTypes[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.PlaneTypes.Count)];
            GeneratedPlane.Creator = creator;

            if (GeneratedPlane.PlaneType == "material")
            {
                GeneratedPlane.PlaneSize = creation_myth.MythObjectData.PlaneSizes[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.PlaneSizes.Count)];
                GeneratedPlane.Name = GeneratedPlane.PlaneSize + " world";
            }
            else if (GeneratedPlane.PlaneType == "ethereal")
            {
                GeneratedPlane.PlaneSize = "pocket";
                GeneratedPlane.PlaneElement = creation_myth.MythObjectData.PlaneElements[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.PlaneElements.Count)];

            }
            else if (GeneratedPlane.PlaneType == "elemental")
            {
                GeneratedPlane.PlaneSize = creation_myth.MythObjectData.PlaneSizes[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.PlaneSizes.Count)];
                GeneratedPlane.PlaneElement = creation_myth.MythObjectData.PlaneElements[ConfigValues.RandomGenerator.Next(creation_myth.MythObjectData.PlaneElements.Count)];
                GeneratedPlane.Name = GeneratedPlane.PlaneSize + " elemental plane of " + GeneratedPlane.PlaneElement;
            }

            GeneratedPlane.connectPlane(creation_myth.Planes);

            if (GeneratedPlane.PlaneType == "ethereal")
            {
                GeneratedPlane.Name = "ethereal " + GeneratedPlane.PlaneElement + " plane of \"" + GeneratedPlane.NeighbourPlanes[0].Name + "\"";
            }

            // add new plane to the creation myth and the log
            creation_myth.Planes.Add(GeneratedPlane);
            creation_myth.MythObjects.Add(GeneratedPlane);
            creation_myth.Logger.updateLog(GeneratedPlane, "CREATED");
        }

    }
}
