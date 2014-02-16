using System;
using System.Collections.Generic;
using System.Linq;
using IMaxwell.Core.Provider;
using log4net;

namespace IMaxwell.Data.Entity
{
    public class EmployeeProvider : IEmployeeProvider
    {

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Entities _entities;

        /// <summary>
        /// Initialize with Entities
        /// </summary>
        public EmployeeProvider()
        {
            _entities = new Entities();
        }

        /// <summary>
        /// Initialize with the passed entities reference
        /// </summary>
        /// <param name="entities">Reference to IMaxwell entity framework</param>
        public EmployeeProvider(Entities entities)
        {
            _entities = entities;
        }

        /// <summary>
        /// Provide the employee matching the provided Id
        /// </summary>
        /// <param name="id">Unique identifier for employee</param>
        /// <returns>Returns employee matching id</returns>
        public Core.Model.Employee Retrieve(int id)
        {

            var employee = new Core.Model.Employee();

            try
            {
                employee = (from c in _entities.Contacts
                    join e in _entities.Employees on c.ContactID equals e.EmployeeID
                    join ph in _entities.EmployeePayHistories on e.EmployeeID equals ph.EmployeeID
                    join ea in _entities.EmployeeAddresses on e.EmployeeID equals ea.EmployeeID
                    join a in _entities.Addresses on ea.AddressID equals a.AddressID
                    let payLastModified = e.EmployeePayHistories.Max(p => p.ModifiedDate)
                    where e.EmployeeID == id && ph.ModifiedDate == payLastModified
                    select new Core.Model.Employee
                    {
                        EmployeeId = e.EmployeeID,
                        Id = c.ContactID,
                        FirstName = c.FirstName,
                        MiddleName = c.MiddleName,
                        LastName = c.LastName,
                        BirthDate = e.BirthDate,
                        City = a.City,
                        PostalCode = a.PostalCode,
                        SickLeaveHours = e.SickLeaveHours,
                        VacationHours = e.VacationHours,
                        Gender = e.Gender,
                        MaritalStatus = e.MaritalStatus,
                        SalariedFlag = e.SalariedFlag,
                        Rate = ph.Rate.Value,
                        ModifiedDate = e.ModifiedDate
                    }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Unable to retrieve the employee for id {0}", id), ex);
            }

            return employee;

        }

        /// <summary>
        /// Provide collection of current employees
        /// </summary>
        /// <returns>Returns current employees</returns>
        public IEnumerable<Core.Model.Employee> Retrieve()
        {
            var employees = new List<Core.Model.Employee>();

            try
            {
                employees = (from c in _entities.Contacts
                    join e in _entities.Employees on c.ContactID equals e.EmployeeID
                             join ph in _entities.EmployeePayHistories on e.EmployeeID equals ph.EmployeeID
                             join ea in _entities.EmployeeAddresses on e.EmployeeID equals ea.EmployeeID
                             join a in _entities.Addresses on ea.AddressID equals a.AddressID
                             let payLastModified = e.EmployeePayHistories.Max(p => p.ModifiedDate)
                             where ph.ModifiedDate == payLastModified
                    select new Core.Model.Employee
                    {
                        EmployeeId = e.EmployeeID,
                        Id = c.ContactID,
                        FirstName = c.FirstName,
                        MiddleName = c.MiddleName,
                        LastName = c.LastName,
                        BirthDate = e.BirthDate,
                        City = a.City,
                        PostalCode = a.PostalCode,
                        SickLeaveHours = e.SickLeaveHours,
                        VacationHours = e.VacationHours,
                        Gender = e.Gender,
                        MaritalStatus = e.MaritalStatus,
                        SalariedFlag = e.SalariedFlag,
                        Rate = ph.Rate.Value,
                        ModifiedDate = e.ModifiedDate
                    }).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to retrieve contacts", ex);
            }

            return employees;
        }
    }
}
