using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMaxwell.Data.Entity.Integration
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

            var provider = new EmployeeProvider();
            var employees = provider.Retrieve().ToList();

            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Any());

        }

        /// <summary>
        /// Ensure that the contact provider returns the associated employee
        /// </summary>
        [TestMethod]
        public void RetrieveEmployeeTest()
        {

            var provider = new EmployeeProvider();
            var employee = provider.Retrieve(4);

            Assert.IsNotNull(employee);

        }
    }

}
