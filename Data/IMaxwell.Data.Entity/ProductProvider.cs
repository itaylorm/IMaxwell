using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IMaxwell.Core.Provider;
using log4net;

namespace IMaxwell.Data.Entity
{
    /// <summary>
    /// Provides access to Product information
    /// </summary>
    public class ProductProvider : IProductProvider
    {
        
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Entities _entities;

        /// <summary>
        /// Initialize with Entities
        /// </summary>
        public ProductProvider()
        {
            _entities = new Entities();
        }

        /// <summary>
        /// Initialize with the passed entities reference
        /// </summary>
        /// <param name="entities">Reference to IMaxwell entity framework</param>
        public ProductProvider(Entities entities)
        {
            _entities = entities;
        }

        /// <summary>
        /// Provide the product matching the provided Id
        /// </summary>
        /// <param name="id">Unique identifier for product</param>
        /// <returns>Returns product matching id</returns>
        public Core.Model.Product Retrieve(int id)
        {

            var product = new Core.Model.Product();

            try
            {

                product = (from p in _entities.Products
                           where p.ProductID == id
                           select new Core.Model.Product
                           {
                               Id = p.ProductID,
                               ProductNumber = p.ProductNumber,
                               SubCategoryId = p.ProductSubcategoryID,
                               Name = p.Name,
                               Color = p.Color,
                               Cost = p.StandardCost,
                               Price = p.ListPrice,
                               Weight = p.Weight,
                               WeightUnitofMeasure = p.WeightUnitMeasureCode,
                               ModifiedDate = p.ModifiedDate
                           }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve the product for id {0}", id), ex);
            }

            return product;

        }

        /// <summary>
        /// Provide collection of current products
        /// </summary>
        /// <returns>Returns current products</returns>
        public IEnumerable<Core.Model.Product> Retrieve()
        {

            var products = new List<Core.Model.Product>();

            try
            {

                products = (from p in _entities.Products
                            select new Core.Model.Product
                            {
                                Id = p.ProductID,
                                ProductNumber = p.ProductNumber,
                                SubCategoryId = p.ProductSubcategoryID,
                                Name = p.Name,
                                Color = p.Color,
                                Cost = p.StandardCost,
                                Price = p.ListPrice,
                                Weight = p.Weight,
                                WeightUnitofMeasure = p.WeightUnitMeasureCode,
                                ModifiedDate = p.ModifiedDate
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
        public IEnumerable<Core.Model.Product> RetrieveBySubCategory(int subCategoryId)
        {

            var products = new List<Core.Model.Product>();

            try
            {

                products = (from p in _entities.Products
                            where p.ProductSubcategoryID == subCategoryId
                            select new Core.Model.Product
                            {
                                Id = p.ProductID,
                                ProductNumber = p.ProductNumber,
                                SubCategoryId = p.ProductSubcategoryID,
                                Name = p.Name,
                                Color = p.Color,
                                Cost = p.StandardCost,
                                Price = p.ListPrice,
                                Weight = p.Weight,
                                WeightUnitofMeasure = p.WeightUnitMeasureCode,
                                ModifiedDate = p.ModifiedDate
                            }).ToList();

            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve the product for sub category id {0}", subCategoryId), ex);
            }

            return products;
        }

    }
}
