using System.Collections.Generic;

namespace IMaxwell.Core.Model
{
    /// <summary>
    /// Paging support type for returning a subset of matching records
    /// </summary>
    public class ContactResult
    {
        /// <summary>
        /// Operation success flag
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Records returned by the query
        /// </summary>
        public List<Contact> Contacts { get; set; }

        /// <summary>
        /// Provides the total records that can be returned for paging
        /// </summary>
        public int Total { get; set; }

    }
}
