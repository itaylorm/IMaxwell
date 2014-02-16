using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;
using IMaxwell.Data.SqlServer;
using log4net;

namespace IMaxwell.Data.Sql
{
    /// <summary>
    /// Provides contact information
    /// </summary>
    public class ContactProvider : IContactProvider
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Core.IQueryProvider _queryProvider;

        /// <summary>
        /// Initialize passed query provider
        /// for subsequent data operations
        /// </summary>
        /// <param name="queryProvider">Query Provider for data operations</param>
        public ContactProvider(Core.IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

        /// <summary>
        /// Provide the contact matching the provided Id
        /// </summary>
        /// <param name="id">Unique identifier for contact</param>
        /// <returns>Returns contact matching id</returns>
        public Contact Retrieve(int id)
        {
            Contact contact = null;

            try
            {

                var command = String.Format(@"
                SELECT
	              c.ContactId
	              ,c.[FirstName]
                  ,c.[LastName]
                  ,c.[MiddleName]
      
                FROM [iMaxwell].[Person].[Contact] c
                WHERE c.ContactId ='{0}'", id);

                var dataTable = _queryProvider.RetrieveData(command);

                contact = (from DataRow row in dataTable.Rows
                           select new Contact
                           {
                               Id = QueryProvider.RetrieveIntValue(row, "ContactId"),
                               FirstName = QueryProvider.RetrieveStringValue(row, "FirstName"),
                               MiddleName = QueryProvider.RetrieveStringValue(row, "MiddleName"),
                               LastName = QueryProvider.RetrieveStringValue(row, "LastName")
                           }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve contact for id {0}", id), ex);
            }

            return contact;
        }

        /// <summary>
        /// Provide collection of current contacts
        /// </summary>
        /// <returns>Returns current contacts</returns>
        public IEnumerable<Contact> Retrieve()
        {
            var contacts = new List<Contact>();

            try
            {

                const string command = @"
                SELECT
	              c.ContactId
	              ,c.[FirstName]
                  ,c.[LastName]
                  ,c.[MiddleName]
      
              FROM [iMaxwell].[Person].[Contact] c";

                var dataTable = _queryProvider.RetrieveData(command);

                contacts = (from DataRow row in dataTable.Rows
                            select new Contact
                            {
                                Id = QueryProvider.RetrieveIntValue(row, "ContactId"),
                                FirstName = QueryProvider.RetrieveStringValue(row, "FirstName"),
                                MiddleName = QueryProvider.RetrieveStringValue(row, "MiddleName"),
                                LastName = QueryProvider.RetrieveStringValue(row, "LastName")

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
