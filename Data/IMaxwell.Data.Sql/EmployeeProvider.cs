using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMaxwell.Core.Model;
using IMaxwell.Core.Provider;
using IMaxwell.Data.SqlServer;
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

                var command = String.Format(@"
                    SELECT
	                  c.ContactId
	                  ,e.EmployeeID
	                  ,c.[FirstName]
                      ,c.[LastName]
                      ,c.[MiddleName]
	                  ,e.Gender
	                  ,e.MaritalStatus
	                  ,e.SalariedFlag
	                  ,e.SickLeaveHours
	                  ,e.VacationHours
	                  ,e.Title
	                  ,e.BirthDate
	                  ,e.ModifiedDate
	                  ,a.City
	                  ,a.PostalCode
	                  ,ph.Rate
      
                  FROM [iMaxwell].[Person].[Contact] c
                  INNER JOIN iMaxwell.HumanResources.Employee e ON c.ContactID = e.ContactID 
                  INNER JOIN (
  
	                SELECT * 
	                FROM 
		                (
			                SELECT [EmployeeID]
			                  ,[ModifiedDate]
			                  ,[PayFrequency]
			                  ,[Rate]
			                  ,[RateChangeDate]
			                  ,ROW_NUMBER() over (partition by EmployeeId order by ModifiedDate DESC) As Row
			                  FROM iMaxwell.HumanResources.EmployeePayHistory ph1
	                  ) As ph2
	                  Where ph2.Row = 1

                  ) as ph ON e.EmployeeID = ph.EmployeeID
  
                  INNER JOIN iMaxwell.HumanResources.EmployeeAddress ea ON e.EmployeeID = ea.EmployeeID
                  INNER JOIN iMaxwell.Person.[Address] a ON ea.AddressID = a.AddressID
                  WHERE e.EmployeeID ='{0}'", id);

                var dataTable = _queryProvider.RetrieveData(command);

                employee = (from DataRow row in dataTable.Rows
                            select new Employee
                            {
                                Id = QueryProvider.RetrieveIntValue(row, "ContactId"),
                                EmployeeId = QueryProvider.RetrieveIntValue(row, "EmployeeID"),
                                FirstName = QueryProvider.RetrieveStringValue(row, "FirstName"),
                                MiddleName = QueryProvider.RetrieveStringValue(row, "MiddleName"),
                                LastName = QueryProvider.RetrieveStringValue(row, "LastName"),
                                BirthDate = QueryProvider.RetrieveDateTimeValue(row, "BirthDate"),
                                City = QueryProvider.RetrieveStringValue(row, "City"),
                                Gender = QueryProvider.RetrieveStringValue(row, "Gender"),
                                MaritalStatus = QueryProvider.RetrieveStringValue(row, "MaritalStatus"),
                                ModifiedDate = QueryProvider.RetrieveDateTimeValue(row, "ModifiedDate"),
                                PostalCode = QueryProvider.RetrieveStringValue(row, "PostalCode"),
                                SalariedFlag = QueryProvider.RetrieveBooleanValue(row, "SalariedFlag"),
                                SickLeaveHours = QueryProvider.RetrieveIntValue(row, "SickLeaveHours"),
                                Title = QueryProvider.RetrieveStringValue(row, "Title"),
                                VacationHours = QueryProvider.RetrieveIntValue(row, "VacationHours"),
                                Rate = QueryProvider.RetrieveDecimalValue(row, "Rate")
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

                const string command = @"
                    SELECT
	                  c.ContactId
	                  ,e.EmployeeID
	                  ,c.[FirstName]
                      ,c.[LastName]
                      ,c.[MiddleName]
	                  ,e.Gender
	                  ,e.MaritalStatus
	                  ,e.SalariedFlag
	                  ,e.SickLeaveHours
	                  ,e.VacationHours
	                  ,e.Title
	                  ,e.BirthDate
	                  ,e.ModifiedDate
	                  ,a.City
	                  ,a.PostalCode
	                  ,ph.Rate
      
                  FROM [iMaxwell].[Person].[Contact] c
                  INNER JOIN iMaxwell.HumanResources.Employee e ON c.ContactID = e.ContactID 
                  INNER JOIN (
  
	                SELECT * 
	                FROM 
		                (
			                SELECT [EmployeeID]
			                  ,[ModifiedDate]
			                  ,[PayFrequency]
			                  ,[Rate]
			                  ,[RateChangeDate]
			                  ,ROW_NUMBER() over (partition by EmployeeId order by ModifiedDate DESC) As Row
			                  FROM iMaxwell.HumanResources.EmployeePayHistory ph1
	                  ) As ph2
	                  Where ph2.Row = 1

                  ) as ph ON e.EmployeeID = ph.EmployeeID
  
                  INNER JOIN iMaxwell.HumanResources.EmployeeAddress ea ON e.EmployeeID = ea.EmployeeID
                  INNER JOIN iMaxwell.Person.[Address] a ON ea.AddressID = a.AddressID";

                var dataTable = _queryProvider.RetrieveData(command);

                employees = (from DataRow row in dataTable.Rows
                             select new Employee
                             {
                                 Id = QueryProvider.RetrieveIntValue(row, "ContactId"),
                                 EmployeeId = QueryProvider.RetrieveIntValue(row, "EmployeeId"),
                                 FirstName = QueryProvider.RetrieveStringValue(row, "FirstName"),
                                 MiddleName = QueryProvider.RetrieveStringValue(row, "MiddleName"),
                                 LastName = QueryProvider.RetrieveStringValue(row, "LastName"),
                                 BirthDate = QueryProvider.RetrieveDateTimeValue(row, "BirthDate"),
                                 City = QueryProvider.RetrieveStringValue(row, "City"),
                                 Gender = QueryProvider.RetrieveStringValue(row, "Gender"),
                                 MaritalStatus = QueryProvider.RetrieveStringValue(row, "MaritalStatus"),
                                 ModifiedDate = QueryProvider.RetrieveDateTimeValue(row, "ModifiedDate"),
                                 PostalCode = QueryProvider.RetrieveStringValue(row, "PostalCode"),
                                 SalariedFlag = QueryProvider.RetrieveBooleanValue(row, "SalariedFlag"),
                                 SickLeaveHours = QueryProvider.RetrieveIntValue(row, "SickLeaveHours"),
                                 Title = QueryProvider.RetrieveStringValue(row, "Title"),
                                 VacationHours = QueryProvider.RetrieveIntValue(row, "VacationHours"),
                                 Rate = QueryProvider.RetrieveDecimalValue(row, "Rate")

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
