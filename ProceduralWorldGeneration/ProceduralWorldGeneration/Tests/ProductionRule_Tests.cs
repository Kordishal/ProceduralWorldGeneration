using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralWorldGeneration.Grammar;

namespace ProceduralWorldGeneration.Tests
{
    [TestClass()]
    public class ProductionRule_Tests
    {
        private ProductionRule production_rule { get; set; }

        [TestInitialize()]
        public void initialise()
        {
            production_rule = new ProductionRule('F', "FF", 10);
        }

        [TestMethod()]
        public void replaceSymbol_True_Test()
        {
            string test = production_rule.replaceSymbol('F');
            Assert.AreEqual("FF", test);
        }

        [TestMethod()]
        public void isValidProductionRule_True_Test()
        {
            Assert.IsTrue(production_rule.isValidProductionRule('F'));
        }
    }
}
