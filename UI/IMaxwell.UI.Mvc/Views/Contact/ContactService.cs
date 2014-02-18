using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace IMaxwell.UI.Mvc.Views.Contact
{
    public class ContactService
    {
        private const string BaseUri = "http://IMaxwell.net/Person/api/Contact/";

        public static IEnumerable<Core.Model.Contact> GetContacts()
        {
            using (var httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(BaseUri);
                var contacts = JsonConvert.DeserializeObjectAsync<IEnumerable<Core.Model.Contact>>(response.Result).Result;
                return contacts;
            }
        }

        public static IEnumerable<Core.Model.Contact> GetContacts(int start, int limit)
        {
            using (var httpClient = new HttpClient())
            {
                string request = String.Concat(BaseUri, String.Format("?start={0}&limit={1}", start, limit));


                Task<string> response = httpClient.GetStringAsync(request);
                var contacts = JsonConvert.DeserializeObjectAsync<IEnumerable<Core.Model.Contact>>(response.Result).Result;
                return contacts;
            }
        }

        public static Core.Model.Contact GetContact(int id)
        {
            using (var httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(BaseUri + id);
                return JsonConvert.DeserializeObjectAsync<Core.Model.Contact>(response.Result).Result;
            }
        }
    }
}