using System;
using System.Linq;
using IMaxwell.Data.SqlServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMaxwell.Data.Sql.Integration
{
    /// <summary>
    /// Integrated tests for category provider
    /// </summary>
    [TestClass]
    public class InventoryProviderTest
    {

        /// <summary>
        /// Ensure that categories are returned by retrieve list
        /// </summary>
        [TestMethod]
        public void RetrieveInventoryItemsTest()
        {

            var provider = new InventoryProvider(new QueryProvider("localhost", "IMaxwell"));

            var categories = provider.Retrieve().ToList();

            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Any());

        }

        /// <summary>
        /// Ensure that the inventory provider returns the associated category
        /// </summary>
        [TestMethod]
        public void RetrieveInventoryTest()
        {

            var provider = new InventoryProvider(new QueryProvider("localhost", "IMaxwell"));
            var category = provider.Retrieve(3);

            Assert.IsNotNull(category);

        }
    }
}
