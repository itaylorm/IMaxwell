using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMaxwell.Core.Model
{
    /// <summary>
    /// Paging support type for returning a subset of matching records
    /// </summary>
    public class EmployeeResult
    {
        /// <summary>
        /// Operation success flag
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Records returned by the query
        /// </summary>
        public List<Employee> Employees { get; set; }

        /// <summary>
        /// Provides the total records that can be returned for paging
        /// </summary>
        public int Total { get; set; }

    }
}
