using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;

namespace IMaxwell.Service.Production.Controllers
{

    /// <summary>
    /// Provides access to the iMaxwell category information
    /// </summary>
    public class CategoryController : ApiController
    {

        private readonly ICategoryProvider _categoryProvider;

        /// <summary>
        /// Configure controller to process requests to the specified 
        /// Category provider
        /// </summary>
        /// <param name="categoryProvider">Provider to process requests</param>
        public CategoryController(ICategoryProvider categoryProvider)
        {
            _categoryProvider = categoryProvider;
        }

        /// <summary>
        /// Provides all categories in the system
        /// </summary>
        /// <remarks>GET api/category</remarks>
        /// <returns>Returns the current contacts in system</returns>
        public IEnumerable<Category> Get()
        {
            return _categoryProvider.Retrieve().ToList();
        }


        /// <summary>
        /// Provides the specific category identified by id
        /// If category does not exist, returns an empty category
        /// </summary>
        /// <remarks>// GET api/category/5</remarks>
        /// <param name="id">Unique Identifier (Category Id) for which to return Category information</param>
        /// <returns>Returns category information for the category identified by category id (unique identifier)</returns>
        public Category Get(int id)
        {

            return _categoryProvider.Retrieve(id);

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