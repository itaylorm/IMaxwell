﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;

namespace IMaxwell.Service.Person.Controllers
{

    /// <summary>
    /// Provides access to the iMaxwell contact information
    /// </summary>
    public class ContactController : ApiController
    {

        private readonly IContactProvider _contactProvider;

        /// <summary>
        /// Configure controller to process requests to the specified 
        /// Contact provider
        /// </summary>
        /// <param name="contactProvider">Provider to process requests</param>
        public ContactController(IContactProvider contactProvider)
        {
            _contactProvider = contactProvider;
        }

        /// <summary>
        /// Provides all contacts in the system
        /// </summary>
        /// <remarks>GET api/contact</remarks>
        /// <returns>Returns the current contacts in system</returns>
        public IEnumerable<Contact> Get()
        {
            return _contactProvider.Retrieve().ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<Contact> Get(int start, int limit)
        {

            var allContacts = _contactProvider.Retrieve();
            var contacts = allContacts.Skip(start).Take(limit).ToList();
            return contacts;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public ContactResult Get(int page, int start, int limit)
        {

            var contacts = _contactProvider.Retrieve().ToList();

            return new ContactResult
            {
                Success = true,
                Contacts = contacts.Skip(start).Take(limit).ToList(),
                Total = contacts.Count
            };

        }

        /// <summary>
        /// Provides the specific contact identified by id
        /// If contact does not exist, returns an empty contact
        /// </summary>
        /// <remarks>// GET api/contact/5</remarks>
        /// <param name="id">Unique Identifier (Contact Id) for which to return Contact information</param>
        /// <returns>Returns contact information for the user identified by contact id (unique identifier)</returns>
        public Contact Get(int id)
        {

            return _contactProvider.Retrieve(id);

        }

        // POST api/contact
        public void Post([FromBody]string value)
        {
        }

        // PUT api/contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
}
