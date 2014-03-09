using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;
using IMaxwell.Data.Core;
using log4net;

namespace IMaxwell.Data.Sql
{
    /// <summary>
    /// Provides category information
    /// </summary>
    public class CategoryProvider : ICategoryProvider
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Core.IQueryProvider _queryProvider;

        /// <summary>
        /// Initialize passed query provider
        /// for subsequent data operations
        /// </summary>
        /// <param name="queryProvider">Query Provider for data operations</param>
        public CategoryProvider(Core.IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

        /// <summary>
        /// Provide the category matching the provided Id
        /// </summary>
        /// <param name="id">Unique identifier for category</param>
        /// <returns>Returns category matching id</returns>
        public Category Retrieve(int id)
        {
            Category category = null;

            try
            {

                var dataTable = _queryProvider.RetrieveData("Production.ProductCategoryByProductCategoryId", "ProductCategoryId", id);

                category = (from DataRow row in dataTable.Rows
                           select new Category
                           {
                               Id = DataProvider.RetrieveIntValue(row, "ProductCategoryId"),
                               Name = DataProvider.RetrieveStringValue(row, "Name")
                           }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve category for id {0}", id), ex);
            }

            return category;
        }

        /// <summary>
        /// Provide collection of current categories
        /// </summary>
        /// <returns>Returns current categories</returns>
        public IEnumerable<Category> Retrieve()
        {
            var categories = new List<Category>();

            try
            {

                var dataTable = _queryProvider.RetrieveData("Production.ProductCategorySelect");

                categories = (from DataRow row in dataTable.Rows
                            select new Category
                            {
                                Id = DataProvider.RetrieveIntValue(row, "ProductCategoryId"),
                                Name = DataProvider.RetrieveStringValue(row, "Name")
                            }).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve categories", ex);
            }

            return categories;

        }

    }
}
