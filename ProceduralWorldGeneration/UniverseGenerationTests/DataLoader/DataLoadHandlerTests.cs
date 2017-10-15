using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralWorldGeneration.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorldGeneration.DataLoader.Tests
{
    [TestClass()]
    public class DataLoadHandlerTests
    {

        [TestMethod()]
        public void ReadDomainFileTest()
        {
            DataLoadHandler loader = new DataLoadHandler();
            loader.ReadDomainFile();
            Assert.IsNotNull(loader.Domains);
            Assert.IsTrue(loader.Domains.Count > 0);
        }

        [TestMethod()]
        public void ReadPlaneElementTest()
        {
            DataLoadHandler loader = new DataLoadHandler();
            loader.ReadPlaneElementFile();
            Assert.IsNotNull(loader.PlaneElements);
            Assert.IsTrue(loader.PlaneElements.Count > 0);
        }
    }
}