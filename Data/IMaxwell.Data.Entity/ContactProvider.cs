using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IMaxwell.Core.Provider;
using log4net;

namespace IMaxwell.Data.Entity
{
    /// <summary>
    /// Provides contact information
    /// </summary>
    public class ContactProvider: IContactProvider
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Entities _entities;

        /// <summary>
        /// Initialize with Entities
        /// </summary>
        public ContactProvider()
        {
            _entities = new Entities();
        }

        /// <summary>
        /// Initialize with the passed entities reference
        /// </summary>
        /// <param name="entities">Reference to IMaxwell entity framework</param>
        public ContactProvider(Entities entities)
        {
            _entities = entities;
        }

        /// <summary>
        /// Provide the contact matching the provided Id
        /// </summary>
        /// <param name="id">Unique identifier for contact</param>
        /// <returns>Returns contact matching id</returns>
        public Core.Model.Contact Retrieve(int id)
        {

            var contact = new Core.Model.Contact();
            
            try
            {
                
                contact = (from c in _entities.Contacts
                          where c.ContactID == id
                          select new Core.Model.Contact
                          {
                              Id = c.ContactID,
                              FirstName = c.FirstName,
                              MiddleName = c.MiddleName,
                              LastName = c.LastName
                          }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve the contact for id {0}", id), ex);
            }

            return contact;

        }

        /// <summary>
        /// Provide collection of current contacts
        /// </summary>
        /// <returns>Returns current contacts</returns>
        public IEnumerable<Core.Model.Contact> Retrieve()
        {

            var contacts = new List<Core.Model.Contact>();

            try
            {

                contacts = (from c in _entities.Contacts
                           select new Core.Model.Contact
                           {
                               Id = c.ContactID,
                               FirstName = c.FirstName,
                               MiddleName = c.MiddleName,
                               LastName = c.LastName
                           }).ToList();

            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve contacts", ex);
            }

            return contacts;
        }

    }
}
