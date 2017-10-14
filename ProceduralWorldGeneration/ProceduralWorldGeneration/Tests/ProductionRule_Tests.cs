using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralWorldGeneration.Grammar;

namespace ProceduralWorldGeneration.Tests
{
    [TestClass()]
    public class ProductionRule_Tests
    {
        private ProductionRule ProductionRule { get; set; }

        [TestInitialize()]
        public void Initialise()
        {
            ProductionRule = new ProductionRule('F', "FF", 10);
        }

        [TestMethod()]
        public void ReplaceSymbol_True_Test()
        {
            string test = ProductionRule.replaceSymbol('F');
            Assert.AreEqual("FF", test);
        }

        [TestMethod()]
        public void IsValidProductionRule_True_Test()
        {
            Assert.IsTrue(ProductionRule.isValidProductionRule('F'));
        }
    }
}
