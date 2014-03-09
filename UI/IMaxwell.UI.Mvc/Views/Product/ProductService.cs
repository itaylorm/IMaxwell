using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace IMaxwell.UI.Mvc.Views.Product
{

    /// <summary>
    /// Provides access to products, product categories and product sub categories services
    /// </summary>
    public class ProductService
    {

        private const string BaseUri = "http://IMaxwell.net/Production/api/";

        /// <summary>
        /// Provides products associated with a sub category
        /// </summary>
        /// <param name="subCategoryId">Unique identifier for sub category to which all products belong</param>
        /// <returns>Returns products which belong to passed sub category</returns>
        public static IEnumerable<Core.Model.Product> GetProducts(int subCategoryId)
        {
            using (var httpClient = new HttpClient())
            {

                var request = String.Concat(BaseUri, String.Format("Product/SubCategory/{0}", subCategoryId));

                var response = httpClient.GetStringAsync(request);
                var products = JsonConvert.DeserializeObjectAsync<IEnumerable<Core.Model.Product>>(response.Result).Result;
                return products;
            }
        }

        /// <summary>
        /// Provides sub categories associated with a category
        /// </summary>
        /// <param name="categoryId">Unique identifier for category to which all sub categories belong</param>
        /// <returns>Returns sub categories which belong to passed category</returns>
        public static IEnumerable<Core.Model.SubCategory> GetSubCategories(int categoryId)
        {
            using (var httpClient = new HttpClient())
            {

                var request = String.Concat(BaseUri, String.Format("SubCategory/Category/{0}", categoryId));

                var response = httpClient.GetStringAsync(request);
                var subCategories = JsonConvert.DeserializeObjectAsync<IEnumerable<Core.Model.SubCategory>>(response.Result).Result;
                return subCategories;
            }
        }

        /// <summary>
        /// Provides product categories
        /// </summary>
        /// <returns>Returns product category</returns>
        public static IEnumerable<Core.Model.Category> GetCategories()
        {
            using (var httpClient = new HttpClient())
            {

                var request = String.Concat(BaseUri, "Category");

                var response = httpClient.GetStringAsync(request);
                return JsonConvert.DeserializeObjectAsync<IEnumerable<Core.Model.Category>>(response.Result).Result;

            }
        }

    }
}