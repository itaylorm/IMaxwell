using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IMaxwell.Core.Model
{

    /// <summary>
    /// Represents a user contact
    /// </summary>
    public class Contact : IModel
    {

        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Middle Name
        /// </summary>
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Modified Date
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Last Modified")]
        public DateTime ModifiedDate { get; set; }

    }

}
