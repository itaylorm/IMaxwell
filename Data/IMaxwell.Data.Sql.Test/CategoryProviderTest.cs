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
    /// Ensure that the Mock Query Provider based CategoryProvider methods function correctly
    /// </summary>
    [TestClass]
    public class CategoryProviderTest
    {

        /// <summary>
        /// Ensure that categories retrieved from the mock query provider is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveCategoriesTest()
        {

            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var categoryProvider = new CategoryProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ProductCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            dataTable.Rows.Add(bikeRow);

            var carRow = dataTable.NewRow();
            carRow["ProductCategoryId"] = 2;
            carRow["Name"] = "Car";
            dataTable.Rows.Add(carRow);

            var trainRow = dataTable.NewRow();
            trainRow["ProductCategoryId"] = 3;
            trainRow["Name"] = "Train";
            dataTable.Rows.Add(trainRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var categories = categoryProvider.Retrieve().ToList();

            Assert.IsNotNull(categories);
            Assert.AreEqual(3, categories.Count());

            var categoryBike = categories.ElementAt(0);
            Assert.AreEqual(bikeRow["ProductCategoryId"], categoryBike.Id);
            Assert.AreEqual(bikeRow["Name"], categoryBike.Name);


            var categoryCar = categories.ElementAt(1);
            Assert.AreEqual(carRow["ProductCategoryId"], categoryCar.Id);
            Assert.AreEqual(carRow["Name"], categoryCar.Name);

            var categoryTrain = categories.ElementAt(2);
            Assert.AreEqual(trainRow["ProductCategoryId"], categoryTrain.Id);
            Assert.AreEqual(trainRow["Name"], categoryTrain.Name);

        }

        /// <summary>
        /// Ensure that category retrieved from the mock query provider is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveCategoryTest()
        {

            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var categoryProvider = new CategoryProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ProductCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            dataTable.Rows.Add(bikeRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var category = categoryProvider.Retrieve(1);

            Assert.IsNotNull(category);

            Assert.AreEqual(bikeRow["ProductCategoryId"], category.Id);
            Assert.AreEqual(bikeRow["Name"], category.Name);


        }

    }
}
