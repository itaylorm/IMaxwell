using System;
using System.Linq;
using IMaxwell.Data.SqlServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMaxwell.Data.Sql.Integration
{
    /// <summary>
    /// Integrated tests for employee provider
    /// </summary>
    [TestClass]
    public class EmployeeProviderTest
    {

        /// <summary>
        /// Ensure that the employee provider returns associated employees
        /// </summary>
        [TestMethod]
        public void RetrieveEmployeesTest()
        {

            var provider = new EmployeeProvider(new QueryProvider("localhost", "IMaxwell"));
            var employees = provider.Retrieve().ToList();

            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Any());

        }

        /// <summary>
        /// Ensure that the employee provider returns the associated employee
        /// </summary>
        [TestMethod]
        public void RetrieveEmployeeTest()
        {

            var provider = new EmployeeProvider(new QueryProvider("localhost", "IMaxwell"));
            var employee = provider.Retrieve(4);

            Assert.IsNotNull(employee);

        }
    }
}
