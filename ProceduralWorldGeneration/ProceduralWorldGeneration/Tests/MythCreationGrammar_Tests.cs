using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralWorldGeneration.Grammar;
using ProceduralWorldGeneration.Main;
using System.Collections.Generic;

namespace ProceduralWorldGeneration.Tests
{
    [TestClass]
    public class MythCreationGrammar_Tests
    {
        [TestMethod()]
        public void initialiseProductionRules_ProductionRulesPresent_Test()
        {
            Program.config.ProductionCycleCount = 10;

            MythCreationGrammar test_grammar = new MythCreationGrammar();

            test_grammar.initialiseProductionRules();

            PrivateObject private_object = new PrivateObject(test_grammar);
            Assert.IsNotNull(private_object.GetFieldOrProperty("_production_rules"));
            Assert.IsTrue(0 < ((List<ProductionRule>)private_object.GetFieldOrProperty("_production_rules")).Count);
            CollectionAssert.AllItemsAreNotNull((List<ProductionRule>)private_object.GetFieldOrProperty("_production_rules"));    
        }
    }
}
