using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IMaxwell.Data.Entity.Test
{

    /// <summary>
    /// Ensure that the Entity Framework based ProductProvider methods function correctly
    /// </summary>
    [TestClass]
    public class ProductProviderTest
    {

        /// <summary>
        /// Ensure that products retrieved from the mock entity framework is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveProductsTest()
        {

            var data = new List<Product> 
            { 
                new Product 
                { 
                    ProductID= 1, 
                    ProductNumber = "ABC1",
                    ProductSubcategoryID = 1, 
                    Name = "Bike" ,
                    Color = "Red",
                    ModifiedDate = DateTime.Now.AddMonths(-1),
                    ListPrice = 200,
                    StandardCost = 50,
                    Weight = 60,
                    WeightUnitMeasureCode = "LB"
                }, 
                new Product 
                { 
                    ProductID = 2, 
                    ProductNumber = "ABD1",
                    ProductSubcategoryID = 1, 
                    Name= "Car",
                    Color="Blue",
                    ModifiedDate = DateTime.Now.AddMonths(-2),
                    ListPrice = 300,
                    StandardCost = 100,
                    Weight = 5000,
                    WeightUnitMeasureCode = "LB"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var provider = new ProductProvider(mockContext.Object);

            var products = provider.Retrieve().ToList();

            Assert.IsNotNull(products);
            Assert.AreEqual(2, products.Count());

            var productBike = products.ElementAt(0);
            var originalBike = data.ElementAt(0);
            Assert.AreEqual(originalBike.ProductID, productBike.Id);
            Assert.AreEqual(originalBike.ProductSubcategoryID, productBike.SubCategoryId);
            Assert.AreEqual(originalBike.Name, productBike.Name);

            var productCar = products.ElementAt(1);
            var originalCar = data.ElementAt(1);
            Assert.AreEqual(originalCar.ProductID, productCar.Id);
            Assert.AreEqual(originalCar.ProductSubcategoryID, productCar.SubCategoryId);
            Assert.AreEqual(originalCar.Name, productCar.Name);

        }

        /// <summary>
        /// Ensure that product retrieved from the mock entity framework is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveProductTest()
        {

            var data = new List<Product> 
            { 
                new Product 
                { 
                    ProductID= 1, 
                    ProductNumber = "ABC1",
                    ProductSubcategoryID = 1, 
                    Name = "Bike" ,
                    Color = "Red",
                    ModifiedDate = DateTime.Now.AddMonths(-1),
                    ListPrice = 200,
                    StandardCost = 50,
                    Weight = 60,
                    WeightUnitMeasureCode = "LB"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var provider = new ProductProvider(mockContext.Object);

            var product = provider.Retrieve(1);

            Assert.IsNotNull(product);

            var originalBike = data.ElementAt(0);
            Assert.AreEqual(originalBike.ProductID, product.Id);
            Assert.AreEqual(originalBike.ProductSubcategoryID, product.SubCategoryId);
            Assert.AreEqual(originalBike.Name, product.Name);

        }

        /// <summary>
        /// Ensure that products retrieved by sub category id from the mock entity framework is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveProductsBySubCategoryIdTest()
        {

            var data = new List<Product> 
            { 
                new Product 
                { 
                    ProductID= 1, 
                    ProductNumber = "ABC1",
                    ProductSubcategoryID = 1, 
                    Name = "Bike" ,
                    Color = "Red",
                    ModifiedDate = DateTime.Now.AddMonths(-1),
                    ListPrice = 200,
                    StandardCost = 50,
                    Weight = 60,
                    WeightUnitMeasureCode = "LB"
                }, 
                new Product 
                { 
                    ProductID = 2, 
                    ProductNumber = "ABD1",
                    ProductSubcategoryID = 1, 
                    Name= "Car",
                    Color="Blue",
                    ModifiedDate = DateTime.Now.AddMonths(-2),
                    ListPrice = 300,
                    StandardCost = 100,
                    Weight = 5000,
                    WeightUnitMeasureCode = "LB"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var provider = new ProductProvider(mockContext.Object);

            var products = provider.RetrieveBySubCategory(1).ToList();

            Assert.IsNotNull(products);
            Assert.AreEqual(2, products.Count());

            var productBike = products.ElementAt(0);
            var originalBike = data.ElementAt(0);
            Assert.AreEqual(originalBike.ProductID, productBike.Id);
            Assert.AreEqual(originalBike.ProductSubcategoryID, productBike.SubCategoryId);
            Assert.AreEqual(originalBike.Name, productBike.Name);

            var productCar = products.ElementAt(1);
            var originalCar = data.ElementAt(1);
            Assert.AreEqual(originalCar.ProductID, productCar.Id);
            Assert.AreEqual(originalCar.ProductSubcategoryID, productCar.SubCategoryId);
            Assert.AreEqual(originalCar.Name, productCar.Name);

        }

    }
}
