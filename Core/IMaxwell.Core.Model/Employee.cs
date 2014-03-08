using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace IMaxwell.Core.Model
{
    /// <summary>
    /// An employee
    /// </summary>
    public class Employee : Contact
    {

        /// <summary>
        /// Employee Identifier
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [DisplayName("Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Marital Status
        /// </summary>
        [DisplayName("Marital Status")]
        public string MaritalStatus { get; set; }

        /// <summary>
        /// Salaried Flag
        /// </summary>
        [DisplayName("Salaried")]
        public bool SalariedFlag { get; set; }

        /// <summary>
        /// Sick Leave Hours
        /// </summary>
        [DisplayName("Sick Hours")]
        public int SickLeaveHours { get; set; }

        /// <summary>
        /// Vacation Hours
        /// </summary>
        [DisplayName("Vacation Hours")]
        public int VacationHours { get; set; }

        /// <summary>
        /// Employee Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Birth Date
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Postal Code
        /// </summary>
        [DisplayName("Zip Code")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Pay Rate
        /// </summary>
        [CurrencyDisplay("en-us")]
        public decimal Rate { get; set; }
    }
}
