using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;
using IMaxwell.Data.Core;
using log4net;

namespace IMaxwell.Data.Sql
{
    /// <summary>
    /// Provides employee information
    /// </summary>
    public class EmployeeProvider : IEmployeeProvider
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Core.IQueryProvider _queryProvider;

        /// <summary>
        /// Initialize passed query provider
        /// for subsequent data operations
        /// </summary>
        /// <param name="queryProvider">Query Provider for data operations</param>
        public EmployeeProvider(Core.IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

        /// <summary>
        /// Provide the contact matching the provided Id
        /// </summary>
        /// <param name="id">Unique identifier for contact</param>
        /// <returns>Returns contact matching id</returns>
        public Employee Retrieve(int id)
        {
            Employee employee = null;

            try
            {

                var dataTable = _queryProvider.RetrieveData("HumanResources.EmployeeWithRateByEmployeeID", "EmployeeID", id);

                employee = (from DataRow row in dataTable.Rows
                            select new Employee
                            {
                                Id = DataProvider.RetrieveIntValue(row, "ContactId"),
                                EmployeeId = DataProvider.RetrieveIntValue(row, "EmployeeID"),
                                FirstName = DataProvider.RetrieveStringValue(row, "FirstName"),
                                MiddleName = DataProvider.RetrieveStringValue(row, "MiddleName"),
                                LastName = DataProvider.RetrieveStringValue(row, "LastName"),
                                BirthDate = DataProvider.RetrieveDateTimeValue(row, "BirthDate"),
                                City = DataProvider.RetrieveStringValue(row, "City"),
                                Gender = DataProvider.RetrieveStringValue(row, "Gender"),
                                MaritalStatus = DataProvider.RetrieveStringValue(row, "MaritalStatus"),
                                ModifiedDate = DataProvider.RetrieveDateTimeValue(row, "ModifiedDate"),
                                PostalCode = DataProvider.RetrieveStringValue(row, "PostalCode"),
                                SalariedFlag = DataProvider.RetrieveBooleanValue(row, "SalariedFlag"),
                                SickLeaveHours = DataProvider.RetrieveIntValue(row, "SickLeaveHours"),
                                Title = DataProvider.RetrieveStringValue(row, "Title"),
                                VacationHours = DataProvider.RetrieveIntValue(row, "VacationHours"),
                                Rate = DataProvider.RetrieveDecimalValue(row, "Rate")
                            }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve employee for id {0}", id), ex);
            }

            return employee;
        }

        /// <summary>
        /// Provide collection of current employees
        /// </summary>
        /// <returns>Returns current employees</returns>
        public IEnumerable<Employee> Retrieve()
        {
            var employees = new List<Employee>();

            try
            {

                var dataTable = _queryProvider.RetrieveData("HumanResources.EmployeeWithRateSelect");

                employees = (from DataRow row in dataTable.Rows
                             select new Employee
                             {
                                 Id = DataProvider.RetrieveIntValue(row, "ContactId"),
                                 EmployeeId = DataProvider.RetrieveIntValue(row, "EmployeeId"),
                                 FirstName = DataProvider.RetrieveStringValue(row, "FirstName"),
                                 MiddleName = DataProvider.RetrieveStringValue(row, "MiddleName"),
                                 LastName = DataProvider.RetrieveStringValue(row, "LastName"),
                                 BirthDate = DataProvider.RetrieveDateTimeValue(row, "BirthDate"),
                                 City = DataProvider.RetrieveStringValue(row, "City"),
                                 Gender = DataProvider.RetrieveStringValue(row, "Gender"),
                                 MaritalStatus = DataProvider.RetrieveStringValue(row, "MaritalStatus"),
                                 ModifiedDate = DataProvider.RetrieveDateTimeValue(row, "ModifiedDate"),
                                 PostalCode = DataProvider.RetrieveStringValue(row, "PostalCode"),
                                 SalariedFlag = DataProvider.RetrieveBooleanValue(row, "SalariedFlag"),
                                 SickLeaveHours = DataProvider.RetrieveIntValue(row, "SickLeaveHours"),
                                 Title = DataProvider.RetrieveStringValue(row, "Title"),
                                 VacationHours = DataProvider.RetrieveIntValue(row, "VacationHours"),
                                 Rate = DataProvider.RetrieveDecimalValue(row, "Rate")

                             }).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve employees", ex);
            }

            return employees;

        }

    }
}
