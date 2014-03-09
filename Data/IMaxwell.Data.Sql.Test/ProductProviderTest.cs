using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IMaxwell.Data.Sql.Test
{
    /// <summary>
    /// Ensure that the Entity Framework based QueryProvider methods function correctly
    /// </summary>
    [TestClass]
    public class ProductProviderTest
    {

        /// <summary>
        /// Ensure that products retrieved from the mock mock query provider is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveProductsTest()
        {
            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var productProvider = new ProductProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ProductId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductId"] = 1;
            bikeRow["ProductSubCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            dataTable.Rows.Add(bikeRow);

            var carRow = dataTable.NewRow();
            carRow["ProductId"] = 2;
            carRow["ProductSubCategoryId"] = 1;
            carRow["Name"] = "Car";
            dataTable.Rows.Add(carRow);

            var trainRow = dataTable.NewRow();
            trainRow["ProductId"] = 3;
            trainRow["ProductSubCategoryId"] = 1;
            trainRow["Name"] = "Train";
            dataTable.Rows.Add(trainRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var products = productProvider.Retrieve().ToList();

            Assert.IsNotNull(products);
            Assert.AreEqual(3, products.Count());

            var productBike = products.ElementAt(0);
            Assert.AreEqual(bikeRow["ProductId"], productBike.Id);
            Assert.AreEqual(bikeRow["ProductSubCategoryId"], productBike.SubCategoryId);
            Assert.AreEqual(bikeRow["Name"], productBike.Name);


            var productCar = products.ElementAt(1);
            Assert.AreEqual(carRow["ProductId"], productCar.Id);
            Assert.AreEqual(carRow["ProductSubCategoryId"], productCar.SubCategoryId);
            Assert.AreEqual(carRow["Name"], productCar.Name);

            var productTrain = products.ElementAt(2);
            Assert.AreEqual(trainRow["ProductId"], productTrain.Id);
            Assert.AreEqual(trainRow["ProductSubCategoryId"], productTrain.SubCategoryId);
            Assert.AreEqual(trainRow["Name"], productTrain.Name);
        }

        /// <summary>
        /// Ensure that product retrieved from the mock query provider is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveProductTest()
        {
            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var productProvider = new ProductProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ProductId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductId"] = 1;
            bikeRow["ProductSubCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            dataTable.Rows.Add(bikeRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var product = productProvider.Retrieve(1);

            Assert.IsNotNull(product);

            Assert.AreEqual(bikeRow["ProductId"], product.Id);
            Assert.AreEqual(bikeRow["ProductSubCategoryId"], product.SubCategoryId);
            Assert.AreEqual(bikeRow["Name"], product.Name);

        }

        /// <summary>
        /// Ensure that products retrieved by sub category id from the mock query provider is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveProductsBySubCategoryIdTest()
        {
            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var productProvider = new ProductProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ProductId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductId"] = 1;
            bikeRow["ProductSubCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            dataTable.Rows.Add(bikeRow);

            var carRow = dataTable.NewRow();
            carRow["ProductId"] = 2;
            carRow["ProductSubCategoryId"] = 1;
            carRow["Name"] = "Car";
            dataTable.Rows.Add(carRow);

            var trainRow = dataTable.NewRow();
            trainRow["ProductId"] = 3;
            trainRow["ProductSubCategoryId"] = 1;
            trainRow["Name"] = "Train";
            dataTable.Rows.Add(trainRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var products = productProvider.RetrieveBySubCategory(1).ToList();

            Assert.IsNotNull(products);
            Assert.AreEqual(3, products.Count());

            var productBike = products.ElementAt(0);
            Assert.AreEqual(bikeRow["ProductId"], productBike.Id);
            Assert.AreEqual(bikeRow["ProductSubCategoryId"], productBike.SubCategoryId);
            Assert.AreEqual(bikeRow["Name"], productBike.Name);


            var productCar = products.ElementAt(1);
            Assert.AreEqual(carRow["ProductId"], productCar.Id);
            Assert.AreEqual(carRow["ProductSubCategoryId"], productCar.SubCategoryId);
            Assert.AreEqual(carRow["Name"], productCar.Name);

            var productTrain = products.ElementAt(2);
            Assert.AreEqual(trainRow["ProductId"], productTrain.Id);
            Assert.AreEqual(trainRow["ProductSubCategoryId"], productTrain.SubCategoryId);
            Assert.AreEqual(trainRow["Name"], productTrain.Name);

        }

    }
}
