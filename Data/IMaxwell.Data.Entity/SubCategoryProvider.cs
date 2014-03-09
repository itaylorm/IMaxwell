using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;
using log4net;

namespace IMaxwell.Data.Entity
{
    /// <summary>
    /// Provides sub category information
    /// </summary>
    public class SubCategoryProvider : ISubCategoryProvider
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Entities _entities;

        /// <summary>
        /// Initialize with Entities
        /// </summary>
        public SubCategoryProvider()
        {
            _entities = new Entities();
        }

        /// <summary>
        /// Initialize with the passed entities reference
        /// </summary>
        /// <param name="entities">Reference to IMaxwell entity framework</param>
        public SubCategoryProvider(Entities entities)
        {
            _entities = entities;
        }

        /// <summary>
        /// Provide the sub category matching the provided Id
        /// </summary>
        /// <param name="categoryId">Unique identifier for category</param>
        /// <returns>Returns sub categories matching category id</returns>
        public IEnumerable<SubCategory> Retrieve(int categoryId)
        {

            var subCategories = new List<SubCategory>();

            try
            {

                subCategories = (from s in _entities.ProductSubcategories
                            where s.ProductCategoryID == categoryId
                            select new SubCategory
                            {
                                Id = s.ProductSubcategoryID,
                                CategoryId = s.ProductCategoryID,
                                Name = s.Name
                            }).ToList();

            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve the sub categories for category id {0}", categoryId), ex);
            }

            return subCategories;

        }

        /// <summary>
        /// Provide collection of current categories
        /// </summary>
        /// <returns>Returns current sub categories</returns>
        public IEnumerable<SubCategory> Retrieve()
        {

            var subCategories = new List<SubCategory>();

            try
            {

                subCategories = (from s in _entities.ProductSubcategories
                              select new SubCategory
                              {
                                  Id = s.ProductSubcategoryID,
                                  CategoryId = s.ProductCategoryID,
                                  Name = s.Name
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
