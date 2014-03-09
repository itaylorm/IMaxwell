using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;

namespace IMaxwell.Service.Production.Controllers
{
    /// <summary>
    /// Provides access to the iMaxwell sub category information
    /// </summary>
    public class SubCategoryController : ApiController
    {

        private readonly ISubCategoryProvider _subCategoryProvider;

        /// <summary>
        /// Configure controller to process requests to the specified 
        /// Sub Category provider
        /// </summary>
        /// <param name="subCategoryProvider">Provider to process requests</param>
        public SubCategoryController(ISubCategoryProvider subCategoryProvider)
        {
            _subCategoryProvider = subCategoryProvider;
        }

        /// <summary>
        /// Provides all sub categories in the system
        /// </summary>
        /// <remarks>GET api/category</remarks>
        /// <returns>Returns the current sub categories in system</returns>
        public IEnumerable<SubCategory> Get()
        {
            return _subCategoryProvider.Retrieve().ToList();
        }

        /// <summary>
        /// Provides the specific sub category identified by id
        /// If sub category does not exist, returns an empty sub category
        /// </summary>
        /// <remarks>// GET api/subcategory/1</remarks>
        /// <param name="id">Unique Identifier (SubCategory Id) for which to return detail</param>
        /// <returns>Returns sub category identified by sub category id (unique identifier)</returns>
        public SubCategory Get(int id)
        {

            return _subCategoryProvider.Retrieve(id);

        }

        /// <summary>
        /// Provides the specific category identified by id
        /// If category does not exist, returns an empty category
        /// </summary>
        /// <remarks>// GET api/subcategory/category/1</remarks>
        /// <param name="id">Unique Identifier (Category Id) for which to return sub categories</param>
        /// <returns>Returns sub categories for the category identified by category id (unique identifier)</returns>
        [Route("api/{controller}/category/{id}")]
        public IEnumerable<SubCategory> GetByCategoryId(int id)
        {

            return _subCategoryProvider.RetrieveByCategoryId(id);

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