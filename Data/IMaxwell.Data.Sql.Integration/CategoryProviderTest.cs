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
    public class CategoryProviderTest
    {

        /// <summary>
        /// Ensure that categories are returned by retrieve list
        /// </summary>
        [TestMethod]
        public void RetrieveCategoriesTest()
        {

            var provider = new CategoryProvider(new QueryProvider("localhost", "IMaxwell"));
            var categories = provider.Retrieve().ToList();

            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Any());

        }

        /// <summary>
        /// Ensure that the category provider returns the associated category
        /// </summary>
        [TestMethod]
        public void RetrieveCategoryTest()
        {

            var provider = new CategoryProvider(new QueryProvider("localhost", "IMaxwell"));
            var category = provider.Retrieve(3);

            Assert.IsNotNull(category);

        }
    }
}
