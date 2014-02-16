using System;
using System.Data;
using IMaxwell.Data.Core;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IMaxwell.Data.Sql.Test
{
    /// <summary>
    /// Ensure that Sql based EmployeeProvider methods function correctly
    /// </summary>
    [TestClass]
    public class EmployeeProviderTest
    {
        /// <summary>
        /// Ensure that a single employee retrieved from the mock query provider is returned 
        /// and no data is lost
        /// </summary>
        [TestMethod]
        public void RetrieveEmployeeTest()
        {

            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);
            var employeeProvider = new EmployeeProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ContactID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("EmployeeID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("MiddleName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("LastName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Gender", typeof(string)));
            dataTable.Columns.Add(new DataColumn("MaritalStatus", typeof(string)));
            dataTable.Columns.Add(new DataColumn("SalariedFlag", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("SickLeaveHours", typeof(int)));
            dataTable.Columns.Add(new DataColumn("VacationHours", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Title", typeof(string)));
            dataTable.Columns.Add(new DataColumn("BirthDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("ModifiedDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("City", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PostalCode", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Rate", typeof(decimal)));

            var taylorRow = dataTable.NewRow();
            taylorRow["ContactID"] = 1;
            taylorRow["EmployeeID"] = 1;
            taylorRow["FirstName"] = "Taylor";
            taylorRow["MiddleName"] = "H";
            taylorRow["LastName"] = "Maxwell";
            taylorRow["Gender"] = "M";
            taylorRow["MaritalStatus"] = "M";
            taylorRow["SalariedFlag"] = true;
            taylorRow["SickLeaveHours"] = 20;
            taylorRow["VacationHours"] = 10;
            taylorRow["Title"] = "CEO";
            taylorRow["BirthDate"] = new DateTime(1963, 3, 4);
            taylorRow["ModifiedDate"] = new DateTime(2013, 12, 31);
            taylorRow["City"] = "Redmond";
            taylorRow["PostalCode"] = "98053";
            taylorRow["Rate"] = 100000.00;
            dataTable.Rows.Add(taylorRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var employee = employeeProvider.Retrieve(1);

            Assert.IsNotNull(employee);

            Assert.AreEqual(taylorRow["ContactID"], employee.Id);
            Assert.AreEqual(taylorRow["EmployeeID"], employee.EmployeeId);
            Assert.AreEqual(taylorRow["FirstName"], employee.FirstName);
            Assert.AreEqual(taylorRow["MiddleName"], employee.MiddleName);
            Assert.AreEqual(taylorRow["LastName"], employee.LastName);
            Assert.AreEqual(taylorRow["Gender"], employee.Gender);
            Assert.AreEqual(taylorRow["MaritalStatus"], employee.MaritalStatus);
            Assert.AreEqual(taylorRow["SalariedFlag"], employee.SalariedFlag);
            Assert.AreEqual(taylorRow["SickLeaveHours"], employee.SickLeaveHours);
            Assert.AreEqual(taylorRow["VacationHours"], employee.VacationHours);
            Assert.AreEqual(taylorRow["Title"], employee.Title);
            Assert.AreEqual(taylorRow["BirthDate"], employee.BirthDate);
            Assert.AreEqual(taylorRow["ModifiedDate"], employee.ModifiedDate);
            Assert.AreEqual(taylorRow["City"], employee.City);
            Assert.AreEqual(taylorRow["PostalCode"], employee.PostalCode);
            Assert.AreEqual(taylorRow["Rate"], employee.Rate);

        }

        /// <summary>
        /// Ensure that contacts retrieved from the mock query provider is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveEmployeesTest()
        {
            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);
            var employeeProvider = new EmployeeProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ContactID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("EmployeeID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("MiddleName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("LastName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Gender", typeof(string)));
            dataTable.Columns.Add(new DataColumn("MaritalStatus", typeof(string)));
            dataTable.Columns.Add(new DataColumn("SalariedFlag", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("SickLeaveHours", typeof(int)));
            dataTable.Columns.Add(new DataColumn("VacationHours", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Title", typeof(string)));
            dataTable.Columns.Add(new DataColumn("BirthDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("ModifiedDate", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("City", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PostalCode", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Rate", typeof(decimal)));

            var taylorRow = dataTable.NewRow();
            taylorRow["ContactID"] = 1;
            taylorRow["EmployeeID"] = 1;
            taylorRow["FirstName"] = "Taylor";
            taylorRow["MiddleName"] = "H";
            taylorRow["LastName"] = "Maxwell";
            taylorRow["Gender"] = "M";
            taylorRow["MaritalStatus"] = "M";
            taylorRow["SalariedFlag"] = true;
            taylorRow["SickLeaveHours"] = 20;
            taylorRow["VacationHours"] = 10;
            taylorRow["Title"] = "CEO";
            taylorRow["BirthDate"] = new DateTime(1963, 3, 4);
            taylorRow["ModifiedDate"] = new DateTime(2013, 12, 31);
            taylorRow["City"] = "Redmond";
            taylorRow["PostalCode"] = "98053";
            taylorRow["Rate"] = 100000.00;
            dataTable.Rows.Add(taylorRow);

            var marciaRow = dataTable.NewRow();
            marciaRow["ContactID"] = 2;
            marciaRow["EmployeeID"] = 2;
            marciaRow["FirstName"] = "Marcia";
            marciaRow["MiddleName"] = "L";
            marciaRow["LastName"] = "Maxwell";
            marciaRow["Gender"] = "F";
            marciaRow["MaritalStatus"] = "M";
            marciaRow["SalariedFlag"] = true;
            marciaRow["SickLeaveHours"] = 20;
            marciaRow["VacationHours"] = 10;
            marciaRow["Title"] = "CTT";
            marciaRow["BirthDate"] = new DateTime(1962, 12, 15);
            marciaRow["ModifiedDate"] = new DateTime(2013, 12, 31);
            marciaRow["City"] = "Redmond";
            marciaRow["PostalCode"] = "98053";
            marciaRow["Rate"] = 50000.00;
            dataTable.Rows.Add(marciaRow);

            var robynRow = dataTable.NewRow();
            robynRow["ContactID"] = 3;
            robynRow["EmployeeID"] = 3;
            robynRow["FirstName"] = "Robyn";
            robynRow["MiddleName"] = "E";
            robynRow["LastName"] = "Maxwell";
            robynRow["Gender"] = "F";
            robynRow["MaritalStatus"] = "S";
            robynRow["SalariedFlag"] = false;
            robynRow["SickLeaveHours"] = 5;
            robynRow["VacationHours"] = 15;
            robynRow["Title"] = "CMO";
            robynRow["BirthDate"] = new DateTime(1992, 11, 14);
            robynRow["ModifiedDate"] = new DateTime(2013, 12, 31);
            robynRow["City"] = "Redmond";
            robynRow["PostalCode"] = "98053";
            robynRow["Rate"] = 20.00;
            dataTable.Rows.Add(robynRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var employees = employeeProvider.Retrieve().ToList();

            Assert.IsNotNull(employees);
            Assert.AreEqual(3, employees.Count());

            var employeeTaylor = employees.ElementAt(0);
            Assert.AreEqual(taylorRow["ContactID"], employeeTaylor.Id);
            Assert.AreEqual(taylorRow["EmployeeID"], employeeTaylor.EmployeeId);
            Assert.AreEqual(taylorRow["FirstName"], employeeTaylor.FirstName);
            Assert.AreEqual(taylorRow["MiddleName"], employeeTaylor.MiddleName);
            Assert.AreEqual(taylorRow["LastName"], employeeTaylor.LastName);
            Assert.AreEqual(taylorRow["Gender"], employeeTaylor.Gender);
            Assert.AreEqual(taylorRow["MaritalStatus"], employeeTaylor.MaritalStatus);
            Assert.AreEqual(taylorRow["SalariedFlag"], employeeTaylor.SalariedFlag);
            Assert.AreEqual(taylorRow["SickLeaveHours"], employeeTaylor.SickLeaveHours);
            Assert.AreEqual(taylorRow["VacationHours"], employeeTaylor.VacationHours);
            Assert.AreEqual(taylorRow["Title"], employeeTaylor.Title);
            Assert.AreEqual(taylorRow["BirthDate"], employeeTaylor.BirthDate);
            Assert.AreEqual(taylorRow["ModifiedDate"], employeeTaylor.ModifiedDate);
            Assert.AreEqual(taylorRow["City"], employeeTaylor.City);
            Assert.AreEqual(taylorRow["PostalCode"], employeeTaylor.PostalCode);
            Assert.AreEqual(taylorRow["Rate"], employeeTaylor.Rate);

            var employeeMarcia = employees.ElementAt(1);
            Assert.AreEqual(marciaRow["ContactID"], employeeMarcia.Id);
            Assert.AreEqual(marciaRow["EmployeeID"], employeeMarcia.EmployeeId);
            Assert.AreEqual(marciaRow["FirstName"], employeeMarcia.FirstName);
            Assert.AreEqual(marciaRow["MiddleName"], employeeMarcia.MiddleName);
            Assert.AreEqual(marciaRow["LastName"], employeeMarcia.LastName);
            Assert.AreEqual(marciaRow["Gender"], employeeMarcia.Gender);
            Assert.AreEqual(marciaRow["MaritalStatus"], employeeMarcia.MaritalStatus);
            Assert.AreEqual(marciaRow["SalariedFlag"], employeeMarcia.SalariedFlag);
            Assert.AreEqual(marciaRow["SickLeaveHours"], employeeMarcia.SickLeaveHours);
            Assert.AreEqual(marciaRow["VacationHours"], employeeMarcia.VacationHours);
            Assert.AreEqual(marciaRow["Title"], employeeMarcia.Title);
            Assert.AreEqual(marciaRow["BirthDate"], employeeMarcia.BirthDate);
            Assert.AreEqual(marciaRow["ModifiedDate"], employeeMarcia.ModifiedDate);
            Assert.AreEqual(marciaRow["City"], employeeMarcia.City);
            Assert.AreEqual(marciaRow["PostalCode"], employeeMarcia.PostalCode);
            Assert.AreEqual(marciaRow["Rate"], employeeMarcia.Rate);

            var employeeRobyn = employees.ElementAt(2);
            Assert.AreEqual(robynRow["ContactID"], employeeRobyn.Id);
            Assert.AreEqual(robynRow["EmployeeID"], employeeRobyn.EmployeeId);
            Assert.AreEqual(robynRow["FirstName"], employeeRobyn.FirstName);
            Assert.AreEqual(robynRow["MiddleName"], employeeRobyn.MiddleName);
            Assert.AreEqual(robynRow["LastName"], employeeRobyn.LastName);
            Assert.AreEqual(robynRow["Gender"], employeeRobyn.Gender);
            Assert.AreEqual(robynRow["MaritalStatus"], employeeRobyn.MaritalStatus);
            Assert.AreEqual(robynRow["SalariedFlag"], employeeRobyn.SalariedFlag);
            Assert.AreEqual(robynRow["SickLeaveHours"], employeeRobyn.SickLeaveHours);
            Assert.AreEqual(robynRow["VacationHours"], employeeRobyn.VacationHours);
            Assert.AreEqual(robynRow["Title"], employeeRobyn.Title);
            Assert.AreEqual(robynRow["BirthDate"], employeeRobyn.BirthDate);
            Assert.AreEqual(robynRow["ModifiedDate"], employeeRobyn.ModifiedDate);
            Assert.AreEqual(robynRow["City"], employeeRobyn.City);
            Assert.AreEqual(robynRow["PostalCode"], employeeRobyn.PostalCode);
            Assert.AreEqual(robynRow["Rate"], employeeRobyn.Rate);

        }
    }
}
