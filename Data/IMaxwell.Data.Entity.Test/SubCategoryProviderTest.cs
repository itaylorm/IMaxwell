using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IMaxwell.Data.Entity.Test
{

    /// <summary>
    /// Ensure that the Entity Framework based SubCategoryProvider methods function correctly
    /// </summary>
    [TestClass]
    public class SubCategoryProviderTest
    {

        /// <summary>
        /// Ensure that sub categories retrieved from the mock entity framework is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveSubCategoriesTest()
        {

            var data = new List<ProductSubcategory> 
            { 
                new ProductSubcategory { ProductSubcategoryID= 1, ProductCategoryID = 1, Name = "Bike" }, 
                new ProductSubcategory { ProductSubcategoryID = 2, ProductCategoryID = 1, Name= "Car"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<ProductSubcategory>>();
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.ProductSubcategories).Returns(mockSet.Object);

            var provider = new SubCategoryProvider(mockContext.Object);

            var subCategories = provider.Retrieve().ToList();

            Assert.IsNotNull(subCategories);
            Assert.AreEqual(2, subCategories.Count());

            var subCategoryBike = subCategories.ElementAt(0);
            var originalBike = data.ElementAt(0);
            Assert.AreEqual(originalBike.ProductSubcategoryID, subCategoryBike.Id);
            Assert.AreEqual(originalBike.ProductCategoryID, subCategoryBike.CategoryId);
            Assert.AreEqual(originalBike.Name, subCategoryBike.Name);

            var subCategoryCar = subCategories.ElementAt(1);
            var originalCar = data.ElementAt(1);
            Assert.AreEqual(originalCar.ProductSubcategoryID, subCategoryCar.Id);
            Assert.AreEqual(originalCar.ProductCategoryID, subCategoryCar.CategoryId);
            Assert.AreEqual(originalCar.Name, subCategoryCar.Name);

        }

        /// <summary>
        /// Ensure that sub category identified by sub category id is retrieved from the mock entity framework and returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveSubCategoryTest()
        {

            var data = new List<ProductSubcategory> 
            { 
                new ProductSubcategory { ProductSubcategoryID= 1, ProductCategoryID = 1, Name = "Bike" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<ProductSubcategory>>();
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.ProductSubcategories).Returns(mockSet.Object);

            var provider = new SubCategoryProvider(mockContext.Object);

            var subCategory = provider.Retrieve(1);

            Assert.IsNotNull(subCategory);

            var originalBike = data.ElementAt(0);
            Assert.AreEqual(originalBike.ProductSubcategoryID, subCategory.Id);
            Assert.AreEqual(originalBike.ProductCategoryID, subCategory.CategoryId);
            Assert.AreEqual(originalBike.Name, subCategory.Name);

        }

        /// <summary>
        /// Ensure that sub categories identified by category id are retrieved from the mock entity framework and returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveSubCategoriesByCategoryIdTest()
        {

            var data = new List<ProductSubcategory> 
            { 
                new ProductSubcategory { ProductSubcategoryID= 1, ProductCategoryID = 1, Name = "Bike" }, 
                new ProductSubcategory { ProductSubcategoryID = 2, ProductCategoryID = 1, Name= "Car"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<ProductSubcategory>>();
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.ProductSubcategories).Returns(mockSet.Object);

            var provider = new SubCategoryProvider(mockContext.Object);

            var subCategories = provider.RetrieveByCategoryId(1).ToList();

            Assert.IsNotNull(subCategories);
            Assert.AreEqual(2, subCategories.Count());

            var categoryBike = subCategories.ElementAt(0);
            var originalBike = data.ElementAt(0);
            Assert.AreEqual(originalBike.ProductSubcategoryID, categoryBike.Id);
            Assert.AreEqual(originalBike.ProductCategoryID, categoryBike.CategoryId);
            Assert.AreEqual(originalBike.Name, categoryBike.Name);

            var categoryCar = subCategories.ElementAt(1);
            var originalCar = data.ElementAt(1);
            Assert.AreEqual(originalCar.ProductSubcategoryID, categoryCar.Id);
            Assert.AreEqual(originalCar.ProductCategoryID, categoryCar.CategoryId);
            Assert.AreEqual(originalCar.Name, categoryCar.Name);

        }

    }
}
