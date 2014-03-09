using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IMaxwell.Data.Entity.Test
{

    /// <summary>
    /// Ensure that the Entity Framework based CategoryProvider methods function correctly
    /// </summary>
    [TestClass]
    public class CategoryProviderTest
    {

        /// <summary>
        /// Ensure that categories retrieved from the mock entity framework is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveCategoriesTest()
        {

            var data = new List<ProductCategory> 
            { 
                new ProductCategory { ProductCategoryID= 1, Name = "Bike" }, 
                new ProductCategory { ProductCategoryID = 2, Name= "Car"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<ProductCategory>>();
            mockSet.As<IQueryable<ProductCategory>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ProductCategory>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ProductCategory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ProductCategory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.ProductCategories).Returns(mockSet.Object);

            var provider = new CategoryProvider(mockContext.Object);

            var categories = provider.Retrieve().ToList();

            Assert.IsNotNull(categories);
            Assert.AreEqual(2, categories.Count());

            var categoryBike = categories.ElementAt(0);
            var originalBike = data.ElementAt(0);
            Assert.AreEqual(originalBike.ProductCategoryID, categoryBike.Id);
            Assert.AreEqual(originalBike.Name, categoryBike.Name);

            var categoryCar = categories.ElementAt(1);
            var originalCar = data.ElementAt(1);
            Assert.AreEqual(originalCar.ProductCategoryID, categoryCar.Id);
            Assert.AreEqual(originalCar.Name, categoryCar.Name);

        }

        /// <summary>
        /// Ensure that category retrieved from the mock entity framework is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveCategoryTest()
        {

            var data = new List<ProductCategory> 
            { 
                new ProductCategory { ProductCategoryID= 1, Name = "Bike" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<ProductCategory>>();
            mockSet.As<IQueryable<ProductCategory>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ProductCategory>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ProductCategory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ProductCategory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.ProductCategories).Returns(mockSet.Object);

            var provider = new CategoryProvider(mockContext.Object);

            var category = provider.Retrieve(1);

            Assert.IsNotNull(category);

            var originalBike = data.ElementAt(0);
            Assert.AreEqual(originalBike.ProductCategoryID, category.Id);
            Assert.AreEqual(originalBike.Name, category.Name);

        }
    }
}
