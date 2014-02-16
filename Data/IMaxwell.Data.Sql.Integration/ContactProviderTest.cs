using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMaxwell.Data.SqlServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMaxwell.Data.Sql.Integration
{
    /// <summary>
    /// Integrated tests for contact provider
    /// </summary>
    [TestClass]
    public class ContactProviderTest
    {
        [TestMethod]
        public void RetrieveContactsTest()
        {

            var provider = new ContactProvider(new QueryProvider("localhost", "IMaxwell"));
            var contacts = provider.Retrieve().ToList();

            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Any());

        }

        /// <summary>
        /// Ensure that the contact provider returns the associated contact
        /// </summary>
        [TestMethod]
        public void RetrieveContactTest()
        {

            var provider = new ContactProvider(new QueryProvider("localhost", "IMaxwell"));
            var contact = provider.Retrieve(4);

            Assert.IsNotNull(contact);

        }
    }
}
