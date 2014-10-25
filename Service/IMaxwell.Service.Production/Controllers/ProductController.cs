using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;

namespace IMaxwell.Service.Production.Controllers
{
    /// <summary>
    /// Provides access to the iMaxwell product information
    /// </summary>
    public class ProductController : ApiController
    {

        private readonly IProductProvider _productProvider;

        /// <summary>
        /// Configure controller to process requests to the specified 
        /// Product provider
        /// </summary>
        /// <param name="productProvider">Provider to process requests</param>
        public ProductController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        /// <summary>
        /// Provides all products in the system
        /// </summary>
        /// <remarks>GET api/product</remarks>
        /// <returns>Returns the current products in system</returns>
        public IEnumerable<Product> Get()
        {
            return _productProvider.Retrieve().ToList();
        }

        /// <summary>
        /// Provides the specific product identified by id
        /// If product does not exist, returns an empty product
        /// </summary>
        /// <remarks>// GET api/product/1</remarks>
        /// <param name="id">Unique Identifier (Product Id) for which to return detail</param>
        /// <returns>Returns product identified by product id (unique identifier)</returns>
        public Product Get(int id)
        {

            return _productProvider.Retrieve(id);

        }

        /// <summary>
        /// Provides the specific category identified by id
        /// If category does not exist, returns an empty category
        /// </summary>
        /// <remarks>// GET api/product/subcategory/1</remarks>
        /// <param name="id">Unique Identifier (Sub Category Id) for which to return products</param>
        /// <returns>Returns products for the sub category identified by sub category id (unique identifier)</returns>
        [Route("api/{controller}/subcategory/{id}")]
        public IEnumerable<Product> GetBySubCategoryId(int id)
        {

            return _productProvider.RetrieveBySubCategory(id);

        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}