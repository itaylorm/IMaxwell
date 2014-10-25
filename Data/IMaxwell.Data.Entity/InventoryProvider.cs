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
    /// Provides access to extended product information
    /// </summary>
    public class InventoryProvider : IInventoryProvider
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Entities _entities;
        private readonly ICategoryProvider _categoryProvider;
        private readonly ISubCategoryProvider _subCategoryProvider;
        private readonly IProductProvider _productProvider;

        /// <summary>
        /// Initialize with Entities
        /// </summary>
        public InventoryProvider()
        {
            _entities = new Entities();
        }

        /// <summary>
        /// Intitialize with passed entity framework reference
        /// </summary>
        /// <param name="entities">Entity framework reference</param>
        public InventoryProvider(Entities entities)
        {
            _entities = entities;
            _categoryProvider = new CategoryProvider(_entities);
            _subCategoryProvider = new SubCategoryProvider(_entities);
            _productProvider = new ProductProvider(_entities);
        }

        /// <summary>
        /// Provide the category matching the provided Id
        /// along with the associated sub categories and products
        /// </summary>
        /// <param name="id">Unique identifier for category</param>
        /// <returns>Returns category matching id as well as associated sub categories and products</returns>
        public Core.Model.Category Retrieve(int id)
        {
            var category = new Category();

            try
            {

                category = _categoryProvider.Retrieve(id);
                category.SubCategories.AddRange(RetrieveSubCategoriesAndProducts(id));

            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve category with associated inventory", ex);
            }

            return category;
        }

        /// <summary>
        /// Provide collection of current categories with associated sub categories and products
        /// </summary>
        /// <returns>Returns current categories with associated sub categories and products</returns>
        public IEnumerable<Core.Model.Category> Retrieve()
        {
            var categories = new List<Category>();

            try
            {
                
                categories = _categoryProvider.Retrieve().ToList();
                categories.ForEach(c => c.SubCategories.AddRange(RetrieveSubCategoriesAndProducts(c.Id)));

            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve inventory", ex);
            }

            return categories;

        }


        /// <summary>
        /// Provide collection of products belonging to the passed sub category unique identifier
        /// </summary>
        /// <param name="subCategoryId">Sub Category unique identifier for which to return products</param>
        /// <returns></returns>
        private IEnumerable<SubCategory> RetrieveSubCategoriesAndProducts(int subCategoryId)
        {

            var subCategories = _subCategoryProvider.RetrieveByCategoryId(subCategoryId).ToList();

            subCategories.ForEach(s => s.Products.AddRange(_productProvider.RetrieveBySubCategory(s.Id)));

            return subCategories;

        }


    }
}
