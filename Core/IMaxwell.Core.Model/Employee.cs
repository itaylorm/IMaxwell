using System;
using System.ComponentModel.DataAnnotations;

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
        public string Gender { get; set; }

        /// <summary>
        /// Marital Status
        /// </summary>
        public string MaritalStatus { get; set; }

        /// <summary>
        /// Salaried Flag
        /// </summary>
        public bool SalariedFlag { get; set; }

        /// <summary>
        /// Sick Leave Hours
        /// </summary>
        public int SickLeaveHours { get; set; }

        /// <summary>
        /// Vacation Hours
        /// </summary>
        public int VacationHours { get; set; }

        /// <summary>
        /// Employee Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Birth Date
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Modified Date
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Postal Code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Pay Rate
        /// </summary>
        public decimal Rate { get; set; }
    }
}
