using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralWorldGeneration.DataStructure;
using ProceduralWorldGeneration.Generator;
using System;
using System.Collections.Generic;

namespace ProceduralWorldGeneration.Tests
{
    [TestClass()]
    public class MythCreator_Tests
    {
        [TestMethod()]
        public void Initialise_NotNull_Test()
        {
            MythCreator myth = new MythCreator();

            myth.initialise(new UserInterfaceData());

            PrivateObject private_object = new PrivateObject(myth);
            Assert.IsNotNull(private_object.GetFieldOrProperty("_user"));
            Assert.IsNotNull(private_object.GetFieldOrProperty("_parser"));
            Assert.IsNotNull(private_object.GetFieldOrProperty("_translator"));
        }
    }
}
