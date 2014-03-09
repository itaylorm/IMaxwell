using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace IMaxwell.UI.Mvc.Views.Contact
{

    /// <summary>
    /// Provides access to contact service
    /// </summary>
    public class ContactService
    {
        private const string BaseUri = "http://IMaxwell.net/Person/api/Contact/";

        /// <summary>
        /// Provides all contacts in system
        /// </summary>
        /// <returns>Returns all contacts</returns>
        public static IEnumerable<Core.Model.Contact> GetContacts()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(BaseUri);
                var contacts = JsonConvert.DeserializeObjectAsync<IEnumerable<Core.Model.Contact>>(response.Result).Result;
                return contacts;
            }
        }

        /// <summary>
        /// Provides all contacts within the specified range
        /// </summary>
        /// <param name="start">Start position within current contacts</param>
        /// <param name="limit">Number of contacts returned</param>
        /// <returns>Returns contacts starting at at start with the number specified by the limit</returns>
        public static IEnumerable<Core.Model.Contact> GetContacts(int start, int limit)
        {
            using (var httpClient = new HttpClient())
            {
                var request = String.Concat(BaseUri, String.Format("?start={0}&limit={1}", start, limit));

                var response = httpClient.GetStringAsync(request);
                var contacts = JsonConvert.DeserializeObjectAsync<IEnumerable<Core.Model.Contact>>(response.Result).Result;
                return contacts;
            }
        }

        /// <summary>
        /// Returns contact details for the contact belonging to the passed id
        /// </summary>
        /// <param name="id">Unique identifier for the contact to return</param>
        /// <returns>Returns contact details belonging to the unique identifier</returns>
        public static Core.Model.Contact GetContact(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(BaseUri + id);
                return JsonConvert.DeserializeObjectAsync<Core.Model.Contact>(response.Result).Result;
            }
        }
    }
}