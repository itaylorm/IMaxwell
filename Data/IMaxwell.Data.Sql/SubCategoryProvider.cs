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
    /// Provides category information
    /// </summary>
    public class SubCategoryProvider : ISubCategoryProvider
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Core.IQueryProvider _queryProvider;

        /// <summary>
        /// Initialize passed query provider
        /// for subsequent data operations
        /// </summary>
        /// <param name="queryProvider">Query Provider for data operations</param>
        public SubCategoryProvider(Core.IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

        /// <summary>
        /// Provide the sub category matching the provided Id
        /// </summary>
        /// <param name="id">Unique identifier for sub category</param>
        /// <returns>Returns sub category information for passed sub category id</returns>
        public SubCategory Retrieve(int id)
        {
            var subCategory = new SubCategory();

            try
            {

                var dataTable = _queryProvider.RetrieveData("Production.ProductSubCategoryByProductSubCategoryId",
                    "ProductSubCategoryId", id);

                subCategory = (from DataRow row in dataTable.Rows
                                 select new SubCategory
                                 {
                                     Id = DataProvider.RetrieveIntValue(row, "ProductSubCategoryId"),
                                     CategoryId = DataProvider.RetrieveIntValue(row, "ProductCategoryId"),
                                     Name = DataProvider.RetrieveStringValue(row, "Name")
                                 }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve the sub category for sub category id {0}", id), ex);
            }

            return subCategory;
        }

        /// <summary>
        /// Provide the sub category matching the provided Id
        /// </summary>
        /// <param name="categoryId">Unique identifier for category</param>
        /// <returns>Returns sub categories matching category id</returns>
        public IEnumerable<SubCategory> RetrieveByCategoryId(int categoryId)
        {
            var subCategories = new List<SubCategory>();

            try
            {

                var dataTable = _queryProvider.RetrieveData("Production.ProductSubCategoryByProductCategoryId", 
                    "ProductCategoryId", categoryId);

                subCategories = (from DataRow row in dataTable.Rows
                                 select new SubCategory
                                 {
                                     Id = DataProvider.RetrieveIntValue(row, "ProductSubCategoryId"),
                                     CategoryId = DataProvider.RetrieveIntValue(row, "ProductCategoryId"),
                                     Name = DataProvider.RetrieveStringValue(row, "Name")
                                 }).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve sub categories", ex);
            }

            return subCategories;
        }

        /// <summary>
        /// Provide collection of current categories
        /// </summary>
        /// <returns>Returns current categories</returns>
        public IEnumerable<SubCategory> Retrieve()
        {

            var subCategories = new List<SubCategory>();

            try
            {

                var dataTable = _queryProvider.RetrieveData("Production.ProductSubCategorySelect");

                subCategories = (from DataRow row in dataTable.Rows
                              select new SubCategory
                              {
                                  Id = DataProvider.RetrieveIntValue(row, "ProductSubCategoryId"),
                                  CategoryId = DataProvider.RetrieveIntValue(row, "ProductCategoryId"),
                                  Name = DataProvider.RetrieveStringValue(row, "Name")
                              }).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve sub categories", ex);
            }

            return subCategories;

        }

    }
}
