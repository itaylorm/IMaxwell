using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IMaxwell.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IMaxwell.Data.Entity.Test
{

    /// <summary>
    /// Ensure that the Entity Framework based InventoryProvider methods function correctly
    /// </summary>
    [TestClass]
    public class InventoryProviderTest
    {

        /// <summary>
        /// Ensure that inventory with categories, sub categories, and products return 
        /// properly from entity framework without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveInventoryItemsTest()
        {

            var categoryData = new List<ProductCategory> 
            { 
                new ProductCategory { ProductCategoryID= 1, Name = "Bike" }, 
                new ProductCategory { ProductCategoryID = 2, Name= "Car"}
            }.AsQueryable();

            var categoryMockSet = new Mock<DbSet<ProductCategory>>();
            categoryMockSet.As<IQueryable<ProductCategory>>().Setup(m => m.Provider).Returns(categoryData.Provider);
            categoryMockSet.As<IQueryable<ProductCategory>>().Setup(m => m.Expression).Returns(categoryData.Expression);
            categoryMockSet.As<IQueryable<ProductCategory>>().Setup(m => m.ElementType).Returns(categoryData.ElementType);
            categoryMockSet.As<IQueryable<ProductCategory>>().Setup(m => m.GetEnumerator()).Returns(categoryData.GetEnumerator());

            var subCategoryData = new List<ProductSubcategory> 
            { 
                new ProductSubcategory { ProductCategoryID= 1, ProductSubcategoryID = 1, Name = "Recreation" }, 
                new ProductSubcategory { ProductCategoryID = 1, ProductSubcategoryID = 2, Name= "Business"},
                new ProductSubcategory { ProductCategoryID = 2, ProductSubcategoryID = 3, Name="Business"},
                new ProductSubcategory { ProductCategoryID= 2, ProductSubcategoryID = 4, Name="Personal"}
            }.AsQueryable();

            var subCategoryMockSet = new Mock<DbSet<ProductSubcategory>>();
            subCategoryMockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.Provider).Returns(subCategoryData.Provider);
            subCategoryMockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.Expression).Returns(subCategoryData.Expression);
            subCategoryMockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.ElementType).Returns(subCategoryData.ElementType);
            subCategoryMockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.GetEnumerator()).Returns(subCategoryData.GetEnumerator());



            var productData = new List<Product> 
            { 
                new Product { ProductID= 1, Name = "Schwinn Fun", ProductSubcategoryID = 1}, 
                new Product { ProductID= 2, Name = "Schwinn Sport", ProductSubcategoryID = 1}, 
                new Product { ProductID= 3, Name = "Schwinn Special", ProductSubcategoryID = 1}, 
                new Product { ProductID= 4, Name = "Schwinn Courier", ProductSubcategoryID = 2}, 
                new Product { ProductID= 5, Name = "Schwinn Powered", ProductSubcategoryID = 2}, 
                new Product { ProductID= 6, Name = "Schwinn Albert", ProductSubcategoryID = 2}, 
                new Product { ProductID= 7, Name = "Taylor Electric", ProductSubcategoryID = 3}, 
                new Product { ProductID= 8, Name = "Taylor Electric Sport", ProductSubcategoryID = 3}, 
                new Product { ProductID= 9, Name = "Taylor Electric Special", ProductSubcategoryID = 3}, 
                new Product { ProductID= 10, Name = "Robyn Electric", ProductSubcategoryID = 4}, 
                new Product { ProductID= 11, Name = "Robyn Electric Sport", ProductSubcategoryID = 4}, 
                new Product { ProductID= 12, Name = "Robyn Electric Special", ProductSubcategoryID = 4}, 
            }.AsQueryable();

            var productMockSet = new Mock<DbSet<Product>>();
            productMockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(productData.Provider);
            productMockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(productData.Expression);
            productMockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(productData.ElementType);
            productMockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(productData.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.ProductCategories).Returns(categoryMockSet.Object);
            mockContext.Setup(c => c.ProductSubcategories).Returns(subCategoryMockSet.Object);
            mockContext.Setup(c => c.Products).Returns(productMockSet.Object);

            var provider = new InventoryProvider(mockContext.Object);

            var categories = provider.Retrieve().ToList();
            var original = RetrieveExpectedData();

            Assert.IsNotNull(categories);
            Assert.AreEqual(2, categories.Count);

            
            for (int i = 0; i < categories.Count; i++)
            {
                var originalCategory = original[0];
                var category = categories[0];
                Assert.AreEqual(originalCategory, category);
            }

        }

        /// <summary>
        /// Ensure that inventory for a single category returns properly from entity framework
        /// </summary>
        [TestMethod]
        public void RetrieveInventoryTest()
        {

            var categoryData = new List<ProductCategory> 
            { 
                new ProductCategory { ProductCategoryID= 1, Name = "Bike" }, 
            }.AsQueryable();

            var categoryMockSet = new Mock<DbSet<ProductCategory>>();
            categoryMockSet.As<IQueryable<ProductCategory>>().Setup(m => m.Provider).Returns(categoryData.Provider);
            categoryMockSet.As<IQueryable<ProductCategory>>().Setup(m => m.Expression).Returns(categoryData.Expression);
            categoryMockSet.As<IQueryable<ProductCategory>>().Setup(m => m.ElementType).Returns(categoryData.ElementType);
            categoryMockSet.As<IQueryable<ProductCategory>>().Setup(m => m.GetEnumerator()).Returns(categoryData.GetEnumerator());

            var subCategoryData = new List<ProductSubcategory> 
            { 
                new ProductSubcategory { ProductCategoryID= 1, ProductSubcategoryID = 1, Name = "Recreation" }, 
                new ProductSubcategory { ProductCategoryID = 1, ProductSubcategoryID = 2, Name= "Business"},
                new ProductSubcategory { ProductCategoryID = 2, ProductSubcategoryID = 3, Name="Business"},
                new ProductSubcategory { ProductCategoryID= 2, ProductSubcategoryID = 4, Name="Personal"}
            }.AsQueryable();

            var subCategoryMockSet = new Mock<DbSet<ProductSubcategory>>();
            subCategoryMockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.Provider).Returns(subCategoryData.Provider);
            subCategoryMockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.Expression).Returns(subCategoryData.Expression);
            subCategoryMockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.ElementType).Returns(subCategoryData.ElementType);
            subCategoryMockSet.As<IQueryable<ProductSubcategory>>().Setup(m => m.GetEnumerator()).Returns(subCategoryData.GetEnumerator());



            var productData = new List<Product> 
            { 
                new Product { ProductID= 1, Name = "Schwinn Fun", ProductSubcategoryID = 1}, 
                new Product { ProductID= 2, Name = "Schwinn Sport", ProductSubcategoryID = 1}, 
                new Product { ProductID= 3, Name = "Schwinn Special", ProductSubcategoryID = 1}, 
                new Product { ProductID= 4, Name = "Schwinn Courier", ProductSubcategoryID = 2}, 
                new Product { ProductID= 5, Name = "Schwinn Powered", ProductSubcategoryID = 2}, 
                new Product { ProductID= 6, Name = "Schwinn Albert", ProductSubcategoryID = 2}, 
                new Product { ProductID= 7, Name = "Taylor Electric", ProductSubcategoryID = 3}, 
                new Product { ProductID= 8, Name = "Taylor Electric Sport", ProductSubcategoryID = 3}, 
                new Product { ProductID= 9, Name = "Taylor Electric Special", ProductSubcategoryID = 3}, 
                new Product { ProductID= 10, Name = "Robyn Electric", ProductSubcategoryID = 4}, 
                new Product { ProductID= 11, Name = "Robyn Electric Sport", ProductSubcategoryID = 4}, 
                new Product { ProductID= 12, Name = "Robyn Electric Special", ProductSubcategoryID = 4}, 
            }.AsQueryable();

            var productMockSet = new Mock<DbSet<Product>>();
            productMockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(productData.Provider);
            productMockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(productData.Expression);
            productMockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(productData.ElementType);
            productMockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(productData.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.ProductCategories).Returns(categoryMockSet.Object);
            mockContext.Setup(c => c.ProductSubcategories).Returns(subCategoryMockSet.Object);
            mockContext.Setup(c => c.Products).Returns(productMockSet.Object);

            var provider = new InventoryProvider(mockContext.Object);

            var category = provider.Retrieve(1);
            var original = RetrieveExpectedData().First(c => c.Id == 1);

            Assert.IsNotNull(category);

            Assert.AreEqual(original, category);

        }


        /// <summary>
        /// Provides sample data for inventory tests
        /// </summary>
        /// <returns></returns>
        private List<Category> RetrieveExpectedData()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Bike",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            CategoryId = 1, 
                            Id=1, 
                            Name = "Recreation",
                            Products = new List<Core.Model.Product>
                            {
                                new Core.Model.Product {Id =1, Name="Schwinn Fun", SubCategoryId = 1},
                                new Core.Model.Product {Id =2, Name="Schwinn Sport", SubCategoryId = 1},
                                new Core.Model.Product {Id =3, Name="Schwinn Special", SubCategoryId = 1}
                            }
                        },
                        new SubCategory
                        {
                            CategoryId = 1, 
                            Id=2, 
                            Name = "Business",
                            Products = new List<Core.Model.Product>
                            {
                                new Core.Model.Product {Id =4, Name="Schwinn Courier", SubCategoryId = 2},
                                new Core.Model.Product {Id =5, Name="Schwinn Powered", SubCategoryId = 2},
                                new Core.Model.Product {Id =6, Name="Schwinn Albert", SubCategoryId = 2}
                            }
                        }
                    }
                },
                new Category
                {
                    Id = 2,
                    Name = "Car",
                    SubCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            CategoryId = 2, 
                            Id=3, 
                            Name = "Recreation",
                            Products = new List<Core.Model.Product>
                            {
                                new Core.Model.Product {Id =7, Name="Taylor Electric", SubCategoryId = 3},
                                new Core.Model.Product {Id =8, Name="Taylor Electric Sport", SubCategoryId = 3},
                                new Core.Model.Product {Id =9, Name="Schwinn Electric Special", SubCategoryId = 3}
                            }
                        },
                        new SubCategory
                        {
                            CategoryId = 2, 
                            Id=4, 
                            Name = "Business",
                            Products = new List<Core.Model.Product>
                            {
                                new Core.Model.Product {Id =10, Name="Robyn Electric", SubCategoryId = 4},
                                new Core.Model.Product {Id =11, Name="Robyn Electric Sport", SubCategoryId = 4},
                                new Core.Model.Product {Id =12, Name="Robyn Electric Special", SubCategoryId = 4}
                            }
                        }
                    }
                }
            };
        }
    }
}
