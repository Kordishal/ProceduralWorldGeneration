using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralWorldGeneration.DataLoader;

namespace UniverseGenerationTests.DataLoader
{
    [TestClass]
    public class DataLoaderHandlerTest
    {
        [TestMethod]
        public void ReadDataFilesTest()
        {
            var loader = new DataLoadHandler();
            loader.ReadDataFiles();

            Assert.IsTrue(loader.Domains != null);
            Assert.IsTrue(loader.PlaneElements != null);
            Assert.IsTrue(loader.PlaneSizes != null);
            Assert.IsTrue(loader.PlaneTypes != null);
            Assert.IsTrue(loader.SpeciesTypes != null);
            Assert.IsTrue(loader.SpeciesTraits != null);
            Assert.IsTrue(loader.TraitCategories != null);
            Assert.IsTrue(loader.CivilizationEthos != null);

            Assert.IsTrue(loader.Domains.TrueForAll(x => x != null));
            Assert.IsTrue(loader.PlaneElements.TrueForAll(x => x != null));
            Assert.IsTrue(loader.PlaneSizes.TrueForAll(x => x != null));
            Assert.IsTrue(loader.PlaneTypes.TrueForAll(x => x != null));
            Assert.IsTrue(loader.SpeciesTypes.TrueForAll(x => x != null));
            Assert.IsTrue(loader.SpeciesTraits.TrueForAll(x => x != null));
            Assert.IsTrue(loader.TraitCategories.TrueForAll(x => x != null));
            Assert.IsTrue(loader.CivilizationEthos.TrueForAll(x => x != null));
        }
    }
}
