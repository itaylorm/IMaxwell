using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;
using IMaxwell.Data.Core;
using log4net;

namespace IMaxwell.Data.Sql
{
    /// <summary>
    /// Provides product information
    /// </summary>
    public class ProductProvider : IProductProvider
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Core.IQueryProvider _queryProvider;

        /// <summary>
        /// Initialize passed query provider
        /// for subsequent data operations
        /// </summary>
        /// <param name="queryProvider">Query Provider for data operations</param>
        public ProductProvider(Core.IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

        /// <summary>
        /// Provide the product matching the provided Id
        /// </summary>
        /// <param name="id">Unique identifier for product</param>
        /// <returns>Returns product matching id</returns>
        public Product Retrieve(int id)
        {
            Product product = null;

            try
            {

                var dataTable = _queryProvider.RetrieveData("Production.ProductByProductId", "ProductId", id);

                product = (from DataRow row in dataTable.Rows
                            select new Product
                            {
                                Id = DataProvider.RetrieveIntValue(row, "ProductId"),
                                SubCategoryId = DataProvider.RetrieveIntValue(row, "ProductSubCategoryId"),
                                Name = DataProvider.RetrieveStringValue(row, "Name")
                            }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve product for id {0}", id), ex);
            }

            return product;
        }

        /// <summary>
        /// Provide collection of current products
        /// </summary>
        /// <returns>Returns current products</returns>
        public IEnumerable<Product> Retrieve()
        {
            var products = new List<Product>();

            try
            {

                var dataTable = _queryProvider.RetrieveData("Production.ProductSelect");

                products = (from DataRow row in dataTable.Rows
                              select new Product
                              {
                                  Id = DataProvider.RetrieveIntValue(row, "ProductId"),
                                  Name = DataProvider.RetrieveStringValue(row, "Name"),
                                  SubCategoryId = DataProvider.RetrieveIntValue(row, "ProductSubCategoryId")
                              }).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve products", ex);
            }

            return products;

        }

        /// <summary>
        /// Provide collection of products belonging to passed subcategory unique identifier
        /// </summary>
        /// <param name="subCategoryId">Sub Category for which to return products</param>
        /// <returns>Returns current products belonging to sub category id</returns>
        public IEnumerable<Product> RetrieveBySubCategory(int subCategoryId)
        {

            var products = new List<Product>();

            try
            {

                var dataTable = _queryProvider.RetrieveData("Production.ProductByProductSubCategoryID", "ProductSubCategoryId", subCategoryId);

                products = (from DataRow row in dataTable.Rows
                            select new Product
                            {
                                Id = DataProvider.RetrieveIntValue(row, "ProductId"),
                                Name = DataProvider.RetrieveStringValue(row, "Name"),
                                SubCategoryId = DataProvider.RetrieveIntValue(row, "ProductSubCategoryId")
                            }).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve products", ex);
            }

            return products;

        }

    }
}
