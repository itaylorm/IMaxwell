using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;

namespace IMaxwell.Service.Production.Controllers
{
    /// <summary>
    /// Provides access to the iMaxwell inventory information
    /// </summary>
    public class InventoryController : ApiController
    {

        private readonly IInventoryProvider _inventoryProvider;

        /// <summary>
        /// Configure controller to process requests to the specified 
        /// Inventory provider
        /// </summary>
        /// <param name="inventoryProvider">Provider to process requests</param>
        public InventoryController(IInventoryProvider inventoryProvider)
        {
            _inventoryProvider = inventoryProvider;
        }


        /// <summary>
        /// Provides all sub categories along with associated sub categories and products in the system
        /// </summary>
        /// <remarks>GET api/inventory</remarks>
        /// <returns>Returns the current categories along with associated sub categories and products in system</returns>
        public IEnumerable<Category> Get()
        {
            return _inventoryProvider.Retrieve();
        }

        /// <summary>
        /// Provides the specific inventory identified by category id along with associated sub categories and products
        /// If category does not exist, returns an empty category
        /// </summary>
        /// <remarks>// GET api/inventory/1</remarks>
        /// <param name="id">Unique Identifier (Category Id) for which to return detail</param>
        /// <returns>Returns category identified by category id (unique identifier) along with associated sub categories and products</returns>
        public Category Get(int id)
        {
            return _inventoryProvider.Retrieve(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Category value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Category value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}