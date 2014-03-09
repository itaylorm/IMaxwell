using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IMaxwell.Data.Sql.Test
{
    /// <summary>
    /// Ensure that the mock query provider based SubCategoryProvider methods function correctly
    /// </summary>
    [TestClass]
    public class SubCategoryProviderTest
    {

        /// <summary>
        /// Ensure that sub categories retrieved from the mock query provider is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveSubCategoriesTest()
        {
            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var subCategoryProvider = new SubCategoryProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("ProductCategoryId", typeof (int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductSubCategoryId"] = 1;
            bikeRow["ProductCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            dataTable.Rows.Add(bikeRow);

            var carRow = dataTable.NewRow();
            carRow["ProductSubCategoryId"] = 2;
            carRow["ProductCategoryId"] = 1;
            carRow["Name"] = "Car";
            dataTable.Rows.Add(carRow);

            var trainRow = dataTable.NewRow();
            trainRow["ProductSubCategoryId"] = 3;
            trainRow["ProductCategoryId"] = 1;
            trainRow["Name"] = "Train";
            dataTable.Rows.Add(trainRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var subCategories = subCategoryProvider.Retrieve().ToList();

            Assert.IsNotNull(subCategories);
            Assert.AreEqual(3, subCategories.Count());

            var subCategoryBike = subCategories.ElementAt(0);
            Assert.AreEqual(bikeRow["ProductSubCategoryId"], subCategoryBike.Id);
            Assert.AreEqual(bikeRow["ProductCategoryId"], subCategoryBike.CategoryId);
            Assert.AreEqual(bikeRow["Name"], subCategoryBike.Name);


            var subCategoryCar = subCategories.ElementAt(1);
            Assert.AreEqual(carRow["ProductSubCategoryId"], subCategoryCar.Id);
            Assert.AreEqual(carRow["ProductCategoryId"], subCategoryCar.CategoryId);
            Assert.AreEqual(carRow["Name"], subCategoryCar.Name);

            var subCategoryTrain = subCategories.ElementAt(2);
            Assert.AreEqual(trainRow["ProductSubCategoryId"], subCategoryTrain.Id);
            Assert.AreEqual(trainRow["ProductCategoryId"], subCategoryTrain.CategoryId);
            Assert.AreEqual(trainRow["Name"], subCategoryTrain.Name);

        }

        /// <summary>
        /// Ensure that sub category identified by sub category id is retrieved from the mock query provider and returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveSubCategoryTest()
        {
            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var subCategoryProvider = new SubCategoryProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("ProductCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductSubCategoryId"] = 1;
            bikeRow["ProductCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            dataTable.Rows.Add(bikeRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var subCategory = subCategoryProvider.Retrieve(1);

            Assert.IsNotNull(subCategory);

            Assert.AreEqual(bikeRow["ProductSubCategoryId"], subCategory.Id);
            Assert.AreEqual(bikeRow["ProductCategoryId"], subCategory.CategoryId);
            Assert.AreEqual(bikeRow["Name"], subCategory.Name);

        }

        /// <summary>
        /// Ensure that sub categories identified by category id are retrieved from the mock query provider and returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveSubCategoriesByCategoryIdTest()
        {
            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var subCategoryProvider = new SubCategoryProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("ProductCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductSubCategoryId"] = 1;
            bikeRow["ProductCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            dataTable.Rows.Add(bikeRow);

            var carRow = dataTable.NewRow();
            carRow["ProductSubCategoryId"] = 2;
            carRow["ProductCategoryId"] = 1;
            carRow["Name"] = "Car";
            dataTable.Rows.Add(carRow);

            var trainRow = dataTable.NewRow();
            trainRow["ProductSubCategoryId"] = 3;
            trainRow["ProductCategoryId"] = 1;
            trainRow["Name"] = "Train";
            dataTable.Rows.Add(trainRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var subCategories = subCategoryProvider.RetrieveByCategoryId(1).ToList();

            Assert.IsNotNull(subCategories);
            Assert.AreEqual(3, subCategories.Count());

            var subCategoryBike = subCategories.ElementAt(0);
            Assert.AreEqual(bikeRow["ProductSubCategoryId"], subCategoryBike.Id);
            Assert.AreEqual(bikeRow["ProductCategoryId"], subCategoryBike.CategoryId);
            Assert.AreEqual(bikeRow["Name"], subCategoryBike.Name);


            var subCategoryCar = subCategories.ElementAt(1);
            Assert.AreEqual(carRow["ProductSubCategoryId"], subCategoryCar.Id);
            Assert.AreEqual(carRow["ProductCategoryId"], subCategoryCar.CategoryId);
            Assert.AreEqual(carRow["Name"], subCategoryCar.Name);

            var subCategoryTrain = subCategories.ElementAt(2);
            Assert.AreEqual(trainRow["ProductSubCategoryId"], subCategoryTrain.Id);
            Assert.AreEqual(trainRow["ProductCategoryId"], subCategoryTrain.CategoryId);
            Assert.AreEqual(trainRow["Name"], subCategoryTrain.Name);
        }

    }
}
