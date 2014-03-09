using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMaxwell.Data.Entity.Integration
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

            var provider = new CategoryProvider();
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

            var provider = new CategoryProvider();
            var category = provider.Retrieve(3);

            Assert.IsNotNull(category);

        }
    }
}
