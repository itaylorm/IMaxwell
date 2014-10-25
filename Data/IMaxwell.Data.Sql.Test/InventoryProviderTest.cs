using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IMaxwell.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IMaxwell.Data.Sql.Test
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

            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var provider = new InventoryProvider(queryProvider.Object);

            var categoryTable = new DataTable();
            categoryTable.Columns.Add(new DataColumn("ProductCategoryId", typeof(int)));
            categoryTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var bikeRow = categoryTable.NewRow();
            bikeRow["ProductCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            categoryTable.Rows.Add(bikeRow);

            var carRow = categoryTable.NewRow();
            carRow["ProductCategoryId"] = 2;
            carRow["Name"] = "Car";
            categoryTable.Rows.Add(carRow);

            queryProvider.Setup(q => q.RetrieveData("Production.ProductCategorySelect")).Returns(categoryTable).Verifiable("RetrieveData for category was not called");

            var subCategoryTable = new DataTable();
            subCategoryTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            subCategoryTable.Columns.Add(new DataColumn("ProductCategoryId", typeof(int)));
            subCategoryTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var subCategoryRow1 = subCategoryTable.NewRow();
            subCategoryRow1["ProductSubCategoryId"] = 1;
            subCategoryRow1["ProductCategoryId"] = 1;
            subCategoryRow1["Name"] = "Recreation";
            subCategoryTable.Rows.Add(subCategoryRow1);

            var subCategoryRow2 = subCategoryTable.NewRow();
            subCategoryRow2["ProductSubCategoryId"] = 2;
            subCategoryRow2["ProductCategoryId"] = 1;
            subCategoryRow2["Name"] = "Business";
            subCategoryTable.Rows.Add(subCategoryRow2);

            var subCategoryRow3 = subCategoryTable.NewRow();
            subCategoryRow3["ProductSubCategoryId"] = 3;
            subCategoryRow3["ProductCategoryId"] = 2;
            subCategoryRow3["Name"] = "Recreation";
            subCategoryTable.Rows.Add(subCategoryRow3);

            var subCategoryRow4 = subCategoryTable.NewRow();
            subCategoryRow4["ProductSubCategoryId"] = 4;
            subCategoryRow4["ProductCategoryId"] = 2;
            subCategoryRow4["Name"] = "Business";
            subCategoryTable.Rows.Add(subCategoryRow4);

            var subCategoryView1 = new DataView(subCategoryTable) {RowFilter = "ProductCategoryId = 1"};
            var subCategoryTable1 = subCategoryView1.ToTable();
            queryProvider.Setup(q => q.RetrieveData("Production.ProductSubCategoryByProductCategoryId", It.IsAny<string>(), 1)).Returns(subCategoryTable1).Verifiable("RetrieveData for sub category was not called");

            var subCategoryView2 = new DataView(subCategoryTable) {RowFilter = "ProductCategoryId = 2"};
            var subCategoryTable2 = subCategoryView2.ToTable();
            queryProvider.Setup(q => q.RetrieveData("Production.ProductSubCategoryByProductCategoryId", It.IsAny<string>(), 2)).Returns(subCategoryTable2).Verifiable("RetrieveData for sub category was not called");

            var productTable = new DataTable();
            productTable.Columns.Add(new DataColumn("ProductId", typeof(int)));
            productTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            productTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var productRow1 = productTable.NewRow();
            productRow1["ProductId"] = 1;
            productRow1["ProductSubCategoryId"] = 1;
            productRow1["Name"] = "Schwinn Fun";
            productTable.Rows.Add(productRow1);

            var productRow2 = productTable.NewRow();
            productRow2["ProductId"] = 2;
            productRow2["ProductSubCategoryId"] = 1;
            productRow2["Name"] = "Schwinn Sport";
            productTable.Rows.Add(productRow2);

            var productRow3 = productTable.NewRow();
            productRow3["ProductId"] = 3;
            productRow3["ProductSubCategoryId"] = 1;
            productRow3["Name"] = "Schwinn Special";
            productTable.Rows.Add(productRow3);

            var productRow4 = productTable.NewRow();
            productRow4["ProductId"] = 4;
            productRow4["ProductSubCategoryId"] = 2;
            productRow4["Name"] = "Schwinn Courier";
            productTable.Rows.Add(productRow4);

            var productRow5 = productTable.NewRow();
            productRow5["ProductId"] = 5;
            productRow5["ProductSubCategoryId"] = 2;
            productRow5["Name"] = "Schwinn Powered";
            productTable.Rows.Add(productRow5);

            var productRow6 = productTable.NewRow();
            productRow6["ProductId"] = 6;
            productRow6["ProductSubCategoryId"] = 2;
            productRow6["Name"] = "Schwinn Albert";
            productTable.Rows.Add(productRow6);

            var productRow7 = productTable.NewRow();
            productRow7["ProductId"] = 7;
            productRow7["ProductSubCategoryId"] = 3;
            productRow7["Name"] = "Taylor Electric";
            productTable.Rows.Add(productRow7);

            var productRow8 = productTable.NewRow();
            productRow8["ProductId"] = 8;
            productRow8["ProductSubCategoryId"] = 3;
            productRow8["Name"] = "Taylor Electric Sport";
            productTable.Rows.Add(productRow8);

            var productRow9 = productTable.NewRow();
            productRow9["ProductId"] = 9;
            productRow9["ProductSubCategoryId"] = 3;
            productRow9["Name"] = "Taylor Electric Special";
            productTable.Rows.Add(productRow9);

            var productRow10 = productTable.NewRow();
            productRow10["ProductId"] = 10;
            productRow10["ProductSubCategoryId"] = 4;
            productRow10["Name"] = "Robyn Electric";
            productTable.Rows.Add(productRow10);

            var productRow11 = productTable.NewRow();
            productRow11["ProductId"] = 11;
            productRow11["ProductSubCategoryId"] = 4;
            productRow11["Name"] = "Robyn Electric Sport";
            productTable.Rows.Add(productRow11);

            var productRow12 = productTable.NewRow();
            productRow12["ProductId"] = 12;
            productRow12["ProductSubCategoryId"] = 4;
            productRow12["Name"] = "Robyn Electric Special";
            productTable.Rows.Add(productRow12);

            var productView1 = new DataView(productTable) { RowFilter = "ProductSubCategoryId = 1" };
            var productTable1 = productView1.ToTable();
            queryProvider.Setup(q => q.RetrieveData("Production.ProductByProductSubCategoryID", It.IsAny<string>(), 1)).Returns(productTable1).Verifiable("RetrieveData was not called");

            var productView2 = new DataView(productTable) { RowFilter = "ProductSubCategoryId = 2" };
            var productTable2 = productView2.ToTable();
            queryProvider.Setup(q => q.RetrieveData("Production.ProductByProductSubCategoryID", It.IsAny<string>(), 2)).Returns(productTable2).Verifiable("RetrieveData was not called");

            var productView3 = new DataView(productTable) { RowFilter = "ProductSubCategoryId = 3" };
            var productTable3 = productView3.ToTable();
            queryProvider.Setup(q => q.RetrieveData("Production.ProductByProductSubCategoryID", It.IsAny<string>(), 3)).Returns(productTable3).Verifiable("RetrieveData was not called");

            var productView4 = new DataView(productTable) { RowFilter = "ProductSubCategoryId = 4" };
            var productTable4 = productView4.ToTable();
            queryProvider.Setup(q => q.RetrieveData("Production.ProductByProductSubCategoryID", It.IsAny<string>(), 4)).Returns(productTable4).Verifiable("RetrieveData was not called");

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

            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var provider = new InventoryProvider(queryProvider.Object);

            var categoryTable = new DataTable();
            categoryTable.Columns.Add(new DataColumn("ProductCategoryId", typeof(int)));
            categoryTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var bikeRow = categoryTable.NewRow();
            bikeRow["ProductCategoryId"] = 1;
            bikeRow["Name"] = "Bike";
            categoryTable.Rows.Add(bikeRow);

            queryProvider.Setup(q => q.RetrieveData("Production.ProductCategoryByProductCategoryId", It.IsAny<string>(), It.IsAny<int>())).Returns(categoryTable).Verifiable("RetrieveData for category was not called");

            var subCategoryTable = new DataTable();
            subCategoryTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            subCategoryTable.Columns.Add(new DataColumn("ProductCategoryId", typeof(int)));
            subCategoryTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var subCategoryRow1 = subCategoryTable.NewRow();
            subCategoryRow1["ProductSubCategoryId"] = 1;
            subCategoryRow1["ProductCategoryId"] = 1;
            subCategoryRow1["Name"] = "Recreation";
            subCategoryTable.Rows.Add(subCategoryRow1);

            var subCategoryRow2 = subCategoryTable.NewRow();
            subCategoryRow2["ProductSubCategoryId"] = 2;
            subCategoryRow2["ProductCategoryId"] = 1;
            subCategoryRow2["Name"] = "Business";
            subCategoryTable.Rows.Add(subCategoryRow2);

            queryProvider.Setup(q => q.RetrieveData("Production.ProductSubCategoryByProductCategoryId", It.IsAny<string>(), It.IsAny<int>())).Returns(subCategoryTable).Verifiable("RetrieveData for sub category was not called");

            var productTable = new DataTable();
            productTable.Columns.Add(new DataColumn("ProductId", typeof(int)));
            productTable.Columns.Add(new DataColumn("ProductSubCategoryId", typeof(int)));
            productTable.Columns.Add(new DataColumn("Name", typeof(string)));

            var productRow1 = productTable.NewRow();
            productRow1["ProductId"] = 1;
            productRow1["ProductSubCategoryId"] = 1;
            productRow1["Name"] = "Schwinn Fun";
            productTable.Rows.Add(productRow1);

            var productRow2 = productTable.NewRow();
            productRow2["ProductId"] = 2;
            productRow2["ProductSubCategoryId"] = 1;
            productRow2["Name"] = "Schwinn Sport";
            productTable.Rows.Add(productRow2);

            var productRow3 = productTable.NewRow();
            productRow3["ProductId"] = 3;
            productRow3["ProductSubCategoryId"] = 1;
            productRow3["Name"] = "Schwinn Special";
            productTable.Rows.Add(productRow3);

            var productRow4 = productTable.NewRow();
            productRow4["ProductId"] = 4;
            productRow4["ProductSubCategoryId"] = 2;
            productRow4["Name"] = "Schwinn Courier";
            productTable.Rows.Add(productRow4);

            var productRow5 = productTable.NewRow();
            productRow5["ProductId"] = 5;
            productRow5["ProductSubCategoryId"] = 2;
            productRow5["Name"] = "Schwinn Powered";
            productTable.Rows.Add(productRow5);

            var productRow6 = productTable.NewRow();
            productRow6["ProductId"] = 6;
            productRow6["ProductSubCategoryId"] = 2;
            productRow6["Name"] = "Schwinn Albert";
            productTable.Rows.Add(productRow6);

            var productView1 = new DataView(productTable) { RowFilter = "ProductSubCategoryId = 1" };
            var productTable1 = productView1.ToTable();
            queryProvider.Setup(q => q.RetrieveData("Production.ProductByProductSubCategoryID", It.IsAny<string>(), 1)).Returns(productTable1).Verifiable("RetrieveData was not called");

            var productView2 = new DataView(productTable) { RowFilter = "ProductSubCategoryId = 2" };
            var productTable2 = productView2.ToTable();
            queryProvider.Setup(q => q.RetrieveData("Production.ProductByProductSubCategoryID", It.IsAny<string>(), 2)).Returns(productTable2).Verifiable("RetrieveData was not called");

            Category category = provider.Retrieve(1);
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
                            Products = new List<IMaxwell.Core.Model.Product>
                            {
                                new IMaxwell.Core.Model.Product {Id =1, Name="Schwinn Fun", SubCategoryId = 1},
                                new IMaxwell.Core.Model.Product {Id =2, Name="Schwinn Sport", SubCategoryId = 1},
                                new IMaxwell.Core.Model.Product {Id =3, Name="Schwinn Special", SubCategoryId = 1}
                            }
                        },
                        new SubCategory
                        {
                            CategoryId = 1, 
                            Id=2, 
                            Name = "Business",
                            Products = new List<IMaxwell.Core.Model.Product>
                            {
                                new IMaxwell.Core.Model.Product {Id =4, Name="Schwinn Courier", SubCategoryId = 2},
                                new IMaxwell.Core.Model.Product {Id =5, Name="Schwinn Powered", SubCategoryId = 2},
                                new IMaxwell.Core.Model.Product {Id =6, Name="Schwinn Albert", SubCategoryId = 2}
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
                            Products = new List<IMaxwell.Core.Model.Product>
                            {
                                new IMaxwell.Core.Model.Product {Id =7, Name="Taylor Electric", SubCategoryId = 3},
                                new IMaxwell.Core.Model.Product {Id =8, Name="Taylor Electric Sport", SubCategoryId = 3},
                                new IMaxwell.Core.Model.Product {Id =9, Name="Schwinn Electric Special", SubCategoryId = 3}
                            }
                        },
                        new SubCategory
                        {
                            CategoryId = 2, 
                            Id=4, 
                            Name = "Business",
                            Products = new List<IMaxwell.Core.Model.Product>
                            {
                                new IMaxwell.Core.Model.Product {Id =10, Name="Robyn Electric", SubCategoryId = 4},
                                new IMaxwell.Core.Model.Product {Id =11, Name="Robyn Electric Sport", SubCategoryId = 4},
                                new IMaxwell.Core.Model.Product {Id =12, Name="Robyn Electric Special", SubCategoryId = 4}
                            }
                        }
                    }
                }
            };
        }
    }
}
