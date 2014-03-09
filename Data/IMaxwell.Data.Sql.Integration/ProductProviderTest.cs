using System.Linq;
using IMaxwell.Data.SqlServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMaxwell.Data.Sql.Integration
{
    /// <summary>
    /// Integrated tests for product provider
    /// </summary>
    [TestClass]
    public class ProductProviderTest
    {

        /// <summary>
        /// Ensure that products are returned by retrieve list
        /// </summary>
        [TestMethod]
        public void RetrieveProductsTest()
        {

            var provider = new ProductProvider(new QueryProvider("localhost", "IMaxwell"));
            var products = provider.Retrieve().ToList();

            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());

        }

        /// <summary>
        /// Ensure that products are returned by retrieve list by sub category id
        /// </summary>
        [TestMethod]
        public void RetrieveProductsBySubCategoryTest()
        {

            var provider = new ProductProvider(new QueryProvider("localhost", "IMaxwell"));
            var products = provider.RetrieveBySubCategory(3).ToList();

            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());

        }

        /// <summary>
        /// Ensure that the product provider returns the associated product
        /// </summary>
        [TestMethod]
        public void RetrieveProductTest()
        {

            var provider = new ProductProvider(new QueryProvider("localhost", "IMaxwell"));
            var product = provider.Retrieve(3);

            Assert.IsNotNull(product);

        }

    }
}
