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
            dataTable.Columns.Add(new DataColumn("ProductNumber", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Color", typeof (string)));
            dataTable.Columns.Add(new DataColumn("StandardCost", typeof (decimal)));
            dataTable.Columns.Add(new DataColumn("ListPrice", typeof (decimal)));
            dataTable.Columns.Add(new DataColumn("Weight", typeof (decimal)));
            dataTable.Columns.Add(new DataColumn("WeightUnitMeasureCode", typeof (string)));
            dataTable.Columns.Add(new DataColumn("ModifiedDate", typeof (DateTime)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductId"] = 1;
            bikeRow["ProductNumber"] = "ABC1";
            bikeRow["ProductSubCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            bikeRow["Color"] = "Red";
            bikeRow["StandardCost"] = 300;
            bikeRow["ListPrice"] = 500;
            bikeRow["Weight"] = 50;
            bikeRow["WeightUnitMeasureCode"] = "LB";
            dataTable.Rows.Add(bikeRow);

            var carRow = dataTable.NewRow();
            carRow["ProductId"] = 2;
            carRow["ProductNumber"] = "ABD2";
            carRow["ProductSubCategoryId"] = 1;
            carRow["Name"] = "Car";
            carRow["Color"] = "Red";
            carRow["StandardCost"] = 200;
            carRow["ListPrice"] = 50000;
            carRow["Weight"] = 5000;
            carRow["WeightUnitMeasureCode"] = "LB";
            dataTable.Rows.Add(carRow);

            var trainRow = dataTable.NewRow();
            trainRow["ProductId"] = 3;
            trainRow["ProductNumber"] = "ADB1";
            trainRow["ProductSubCategoryId"] = 1;
            trainRow["Name"] = "Train";
            trainRow["Color"] = "Blue";
            trainRow["StandardCost"] = 20;
            trainRow["ListPrice"] = 50;
            trainRow["Weight"] = 10000;
            trainRow["WeightUnitMeasureCode"] = "LB";
            dataTable.Rows.Add(trainRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var products = productProvider.Retrieve().ToList();

            Assert.IsNotNull(products);
            Assert.AreEqual(3, products.Count());

            var productBike = products.ElementAt(0);
            Assert.AreEqual(bikeRow["ProductId"], productBike.Id);
            Assert.AreEqual(bikeRow["ProductSubCategoryId"], productBike.SubCategoryId);
            Assert.AreEqual(bikeRow["Name"], productBike.Name);
            Assert.AreEqual(bikeRow["ProductNumber"], productBike.ProductNumber);
            Assert.AreEqual(bikeRow["Color"], productBike.Color);
            Assert.AreEqual(bikeRow["StandardCost"], productBike.Cost);
            Assert.AreEqual(bikeRow["ListPrice"], productBike.Price);
            Assert.AreEqual(bikeRow["Weight"], productBike.Weight);
            Assert.AreEqual(bikeRow["WeightUnitMeasureCode"], productBike.WeightUnitofMeasure);

            var productCar = products.ElementAt(1);
            Assert.AreEqual(carRow["ProductId"], productCar.Id);
            Assert.AreEqual(carRow["ProductSubCategoryId"], productCar.SubCategoryId);
            Assert.AreEqual(carRow["Name"], productCar.Name);
            Assert.AreEqual(carRow["ProductNumber"], productCar.ProductNumber);
            Assert.AreEqual(carRow["Color"], productCar.Color);
            Assert.AreEqual(carRow["StandardCost"], productCar.Cost);
            Assert.AreEqual(carRow["ListPrice"], productCar.Price);
            Assert.AreEqual(carRow["Weight"], productCar.Weight);
            Assert.AreEqual(carRow["WeightUnitMeasureCode"], productCar.WeightUnitofMeasure);

            var productTrain = products.ElementAt(2);
            Assert.AreEqual(trainRow["ProductId"], productTrain.Id);
            Assert.AreEqual(trainRow["ProductSubCategoryId"], productTrain.SubCategoryId);
            Assert.AreEqual(trainRow["Name"], productTrain.Name);
            Assert.AreEqual(trainRow["ProductNumber"], productTrain.ProductNumber);
            Assert.AreEqual(trainRow["Color"], productTrain.Color);
            Assert.AreEqual(trainRow["StandardCost"], productTrain.Cost);
            Assert.AreEqual(trainRow["ListPrice"], productTrain.Price);
            Assert.AreEqual(trainRow["Weight"], productTrain.Weight);
            Assert.AreEqual(trainRow["WeightUnitMeasureCode"], productTrain.WeightUnitofMeasure);

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
            dataTable.Columns.Add(new DataColumn("ProductNumber", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Color", typeof(string)));
            dataTable.Columns.Add(new DataColumn("StandardCost", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("ListPrice", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Weight", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("WeightUnitMeasureCode", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ModifiedDate", typeof(DateTime)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductId"] = 1;
            bikeRow["ProductNumber"] = "ABC1";
            bikeRow["ProductSubCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            bikeRow["Color"] = "Red";
            bikeRow["StandardCost"] = 300;
            bikeRow["ListPrice"] = 500;
            bikeRow["Weight"] = 50;
            bikeRow["WeightUnitMeasureCode"] = "LB";
            dataTable.Rows.Add(bikeRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var product = productProvider.Retrieve(1);

            Assert.IsNotNull(product);

            Assert.AreEqual(bikeRow["ProductId"], product.Id);
            Assert.AreEqual(bikeRow["ProductSubCategoryId"], product.SubCategoryId);
            Assert.AreEqual(bikeRow["Name"], product.Name);
            Assert.AreEqual(bikeRow["ProductNumber"], product.ProductNumber);
            Assert.AreEqual(bikeRow["Color"], product.Color);
            Assert.AreEqual(bikeRow["StandardCost"], product.Cost);
            Assert.AreEqual(bikeRow["ListPrice"], product.Price);
            Assert.AreEqual(bikeRow["Weight"], product.Weight);
            Assert.AreEqual(bikeRow["WeightUnitMeasureCode"], product.WeightUnitofMeasure);

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
            dataTable.Columns.Add(new DataColumn("ProductNumber", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Color", typeof(string)));
            dataTable.Columns.Add(new DataColumn("StandardCost", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("ListPrice", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("Weight", typeof(decimal)));
            dataTable.Columns.Add(new DataColumn("WeightUnitMeasureCode", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ModifiedDate", typeof(DateTime)));

            var bikeRow = dataTable.NewRow();
            bikeRow["ProductId"] = 1;
            bikeRow["ProductNumber"] = "ABC1";
            bikeRow["ProductSubCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            bikeRow["Color"] = "Red";
            bikeRow["StandardCost"] = 300;
            bikeRow["ListPrice"] = 500;
            bikeRow["Weight"] = 50;
            bikeRow["WeightUnitMeasureCode"] = "LB";
            dataTable.Rows.Add(bikeRow);

            var carRow = dataTable.NewRow();
            carRow["ProductId"] = 2;
            carRow["ProductNumber"] = "ABD2";
            carRow["ProductSubCategoryId"] = 1;
            carRow["Name"] = "Car";
            carRow["Color"] = "Red";
            carRow["StandardCost"] = 200;
            carRow["ListPrice"] = 50000;
            carRow["Weight"] = 5000;
            carRow["WeightUnitMeasureCode"] = "LB";
            dataTable.Rows.Add(carRow);

            var trainRow = dataTable.NewRow();
            trainRow["ProductId"] = 3;
            trainRow["ProductNumber"] = "ADB1";
            trainRow["ProductSubCategoryId"] = 1;
            trainRow["Name"] = "Train";
            trainRow["Color"] = "Blue";
            trainRow["StandardCost"] = 20;
            trainRow["ListPrice"] = 50;
            trainRow["Weight"] = 10000;
            trainRow["WeightUnitMeasureCode"] = "LB";
            dataTable.Rows.Add(trainRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var products = productProvider.RetrieveBySubCategory(1).ToList();

            Assert.IsNotNull(products);
            Assert.AreEqual(3, products.Count());

            var productBike = products.ElementAt(0);
            Assert.AreEqual(bikeRow["ProductId"], productBike.Id);
            Assert.AreEqual(bikeRow["ProductSubCategoryId"], productBike.SubCategoryId);
            Assert.AreEqual(bikeRow["Name"], productBike.Name);
            Assert.AreEqual(bikeRow["ProductNumber"], productBike.ProductNumber);
            Assert.AreEqual(bikeRow["Color"], productBike.Color);
            Assert.AreEqual(bikeRow["StandardCost"], productBike.Cost);
            Assert.AreEqual(bikeRow["ListPrice"], productBike.Price);
            Assert.AreEqual(bikeRow["Weight"], productBike.Weight);
            Assert.AreEqual(bikeRow["WeightUnitMeasureCode"], productBike.WeightUnitofMeasure);

            var productCar = products.ElementAt(1);
            Assert.AreEqual(carRow["ProductId"], productCar.Id);
            Assert.AreEqual(carRow["ProductSubCategoryId"], productCar.SubCategoryId);
            Assert.AreEqual(carRow["Name"], productCar.Name);
            Assert.AreEqual(carRow["ProductNumber"], productCar.ProductNumber);
            Assert.AreEqual(carRow["Color"], productCar.Color);
            Assert.AreEqual(carRow["StandardCost"], productCar.Cost);
            Assert.AreEqual(carRow["ListPrice"], productCar.Price);
            Assert.AreEqual(carRow["Weight"], productCar.Weight);
            Assert.AreEqual(carRow["WeightUnitMeasureCode"], productCar.WeightUnitofMeasure);

            var productTrain = products.ElementAt(2);
            Assert.AreEqual(trainRow["ProductId"], productTrain.Id);
            Assert.AreEqual(trainRow["ProductSubCategoryId"], productTrain.SubCategoryId);
            Assert.AreEqual(trainRow["Name"], productTrain.Name);
            Assert.AreEqual(trainRow["ProductNumber"], productTrain.ProductNumber);
            Assert.AreEqual(trainRow["Color"], productTrain.Color);
            Assert.AreEqual(trainRow["StandardCost"], productTrain.Cost);
            Assert.AreEqual(trainRow["ListPrice"], productTrain.Price);
            Assert.AreEqual(trainRow["Weight"], productTrain.Weight);
            Assert.AreEqual(trainRow["WeightUnitMeasureCode"], productTrain.WeightUnitofMeasure);

        }

    }
}
