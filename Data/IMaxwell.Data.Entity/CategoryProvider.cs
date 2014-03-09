using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IMaxwell.Core.Provider;
using log4net;

namespace IMaxwell.Data.Entity
{
    /// <summary>
    /// Provides category information
    /// </summary>
    public class CategoryProvider : ICategoryProvider
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Entities _entities;

        /// <summary>
        /// Initialize with Entities
        /// </summary>
        public CategoryProvider()
        {
            _entities = new Entities();
        }

        /// <summary>
        /// Initialize with the passed entities reference
        /// </summary>
        /// <param name="entities">Reference to IMaxwell entity framework</param>
        public CategoryProvider(Entities entities)
        {
            _entities = entities;
        }

        /// <summary>
        /// Provide the category matching the provided Id
        /// </summary>
        /// <param name="id">Unique identifier for category</param>
        /// <returns>Returns category matching id</returns>
        public Core.Model.Category Retrieve(int id)
        {

            var category = new Core.Model.Category();

            try
            {

                category = (from c in _entities.ProductCategories
                           where c.ProductCategoryID == id
                           select new Core.Model.Category
                           {
                               Id = c.ProductCategoryID,
                               Name = c.Name
                           }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve the category for id {0}", id), ex);
            }

            return category;

        }

        /// <summary>
        /// Provide collection of current categories
        /// </summary>
        /// <returns>Returns current categories</returns>
        public IEnumerable<Core.Model.Category> Retrieve()
        {

            var categories = new List<Core.Model.Category>();

            try
            {

                categories = (from c in _entities.ProductCategories
                            select new Core.Model.Category
                            {
                                Id = c.ProductCategoryID,
                                Name = c.Name
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
