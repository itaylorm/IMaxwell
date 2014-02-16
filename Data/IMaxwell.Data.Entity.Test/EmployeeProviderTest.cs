using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IMaxwell.Data.Entity.Test
{
    /// <summary>
    /// Ensure that the Entity Framework based ContactProvider methods function correctly
    /// </summary>
    [TestClass]
    public class EmployeeProviderTest
    {

        /// <summary>
        /// Ensure that employees retrieved from the mock entity framework is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveEmployeesTest()
        {

            //var data = new List<Employee>
            //{
            //    new Employee
            //    {
            //        EmployeeID   = 1,
            //        ContactID = 1,
            //        Employee1 = new Collection<Employee>(),
            //        Employee2 = new Employee(),
            //        EmployeeDepartmentHistories = new Collection<EmployeeDepartmentHistory>(),
            //        EmployeePayHistories = new Collection<EmployeePayHistory>(),
            //        EmployeeAddresses = new Collection<EmployeeAddress>(),
            //        JobCandidates = new Collection<JobCandidate>(),
            //        PurchaseOrderHeaders = new Collection<PurchaseOrderHeader>(),
            //        Contact = new Contact
            //        {
            //            ContactID=1,
            //            ContactCreditCards = new Collection<ContactCreditCard>(),
            //            Employees = new Collection<Employee>(),
            //            Individuals = new Collection<Individual>()
            //        }
            //    }
            //}.AsQueryable();

            //var data = new List<Employee> 
            //{ 
            //    new Employee
            //    {
            //        EmployeeID=1,
            //        ContactID=1, 
            //        Gender = "M",
            //        BirthDate = new DateTime(1963,3,4), 
            //        VacationHours = 0,
            //        SickLeaveHours = 0,
            //        Contact = new Contact {ContactID = 1, FirstName = "Taylor", MiddleName ="H", LastName = "Maxwell" },
            //        Employee1 = new Employee[] {},
            //        Employee2 = new Employee(),
            //        EmployeeDepartmentHistories = new Collection<EmployeeDepartmentHistory>(),
            //        EmployeeAddresses = new List<EmployeeAddress>
            //        {
            //            new EmployeeAddress
            //            {
            //                AddressID = 1,
            //                Address = new Address 
            //                { 
            //                    AddressID=1, 
            //                    AddressLine1 = "22555 NE Cascara Circle", 
            //                    City="Redmond",
            //                    StateProvince = {StateProvinceCode = "WA", Name = "Washington"},
            //                    PostalCode = "98053"
            //                }
            //            }
            //        },
            //        EmployeePayHistories = new List<EmployeePayHistory>
            //        {
            //            new EmployeePayHistory {EmployeeID = 1, Rate = (decimal)50.0, ModifiedDate = new DateTime(2013, 1,4)},
            //            new EmployeePayHistory {EmployeeID = 1, Rate = (decimal)55.0, ModifiedDate = new DateTime(2013, 6,12)},
            //            new EmployeePayHistory {EmployeeID = 1, Rate = (decimal)60.0, ModifiedDate = new DateTime(2014, 2,8)}
            //        }
            //    }, 
            //    new Employee
            //    {
            //        EmployeeID=2,
            //        ContactID=2, 
            //        Gender = "F",
            //        BirthDate = new DateTime(1962, 12, 15),
            //        VacationHours = 0,
            //        SickLeaveHours = 0,
            //        Contact = new Contact {ContactID = 2, FirstName = "Marcia", MiddleName ="L", LastName = "Maxwell" },
            //        Employee1 = new Employee[] {},
            //        Employee2 = new Employee(),
            //        EmployeeDepartmentHistories = new Collection<EmployeeDepartmentHistory>(),
            //        EmployeeAddresses = new List<EmployeeAddress>
            //        {
            //            new EmployeeAddress
            //            {
            //                AddressID = 1,
            //                Address = new Address 
            //                { 
            //                    AddressID=1, 
            //                    AddressLine1 = "22555 NE Cascara Circle", 
            //                    City="Redmond",
            //                    StateProvince = {StateProvinceCode = "WA", Name = "Washington"},
            //                    PostalCode = "98053"
            //                }
            //            }
            //        },
            //        EmployeePayHistories = new List<EmployeePayHistory>
            //        {
            //            new EmployeePayHistory {EmployeeID = 1, Rate = (decimal)20.0, ModifiedDate = new DateTime(2013, 1,4)},
            //            new EmployeePayHistory {EmployeeID = 1, Rate = (decimal)25.0, ModifiedDate = new DateTime(2013, 6,12)},
            //            new EmployeePayHistory {EmployeeID = 1, Rate = (decimal)30.0, ModifiedDate = new DateTime(2014, 2,8)}
            //        }
            //    }, 
            //    new Employee
            //    {
            //        EmployeeID=3,
            //        ContactID=3, 
            //        BirthDate = new DateTime(1992,11,14),
            //        VacationHours = 0,
            //        SickLeaveHours = 0, 
            //        Contact = new Contact {ContactID=3, FirstName = "Robyn", MiddleName ="E", LastName = "Maxwell" },
            //        Employee1 = new Employee[] {},
            //        Employee2 = new Employee(),
            //        EmployeeDepartmentHistories = new Collection<EmployeeDepartmentHistory>(),
            //        EmployeeAddresses = new List<EmployeeAddress>
            //        {
            //            new EmployeeAddress
            //            {
            //                AddressID = 1,
            //                Address = new Address 
            //                { 
            //                    AddressID=1, 
            //                    AddressLine1 = "22555 NE Cascara Circle", 
            //                    City="Redmond",
            //                    StateProvince = {StateProvinceCode = "WA", Name = "Washington"},
            //                    PostalCode = "98053"
            //                }
            //            }
            //        },
            //        EmployeePayHistories = new List<EmployeePayHistory>
            //        {
            //            new EmployeePayHistory {EmployeeID = 1, Rate = (decimal)10.0, ModifiedDate = new DateTime(2013, 1,4)},
            //            new EmployeePayHistory {EmployeeID = 1, Rate = (decimal)15.0, ModifiedDate = new DateTime(2013, 6,12)},
            //            new EmployeePayHistory {EmployeeID = 1, Rate = (decimal)25.0, ModifiedDate = new DateTime(2014, 2,8)}
            //        }
            //    }, 
            //}.AsQueryable();

            //var mockSet = new Mock<DbSet<Employee>>();
            //mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            //mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            //mockSet.As<IQueryable<Contact>>().Setup(m => m.Join(It.IsAny<Employee>(), contact => contact.ContactID, (employee,contact) => It.IsAny<Employee>(), (Employee,Contact,IEnumerable<Employee>)));
            //var mockContext = new Mock<Entities>();
            //mockContext.Setup(e => e.Employees).Returns(mockSet.Object);

            //var provider = new EmployeeProvider(mockContext.Object);

            //var employees = provider.Retrieve().ToList();

            //Assert.IsNotNull(employees);
            //Assert.AreEqual(3, employees.Count());

            //var taylor = employees.ElementAt(0);
            //Assert.AreEqual(data.ElementAt(0).EmployeeID, taylor.EmployeeId);
            //Assert.AreEqual(data.ElementAt(0).ContactID, taylor.Id);
            //Assert.AreEqual(data.ElementAt(0).Contact.FirstName, taylor.FirstName);
            //Assert.AreEqual(data.ElementAt(0).Contact.MiddleName, taylor.MiddleName);
            //Assert.AreEqual(data.ElementAt(0).Contact.LastName, taylor.LastName);
            //Assert.AreEqual(data.ElementAt(0).Gender, taylor.Gender);

        }

        /// <summary>
        /// Ensure that employee retrieved from the mock entity framework is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveEmployeeTest()
        {

        }
    }
}
