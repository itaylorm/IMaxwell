using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMaxwell.Data.Entity.Integration
{

    /// <summary>
    /// Integrated tests for contact provider
    /// </summary>
    [TestClass]
    public class ContactProviderTest
    {

        /// <summary>
        /// Ensure that contacts are returned by retrieve list
        /// </summary>
        [TestMethod]
        public void RetrieveContactsTest()
        {

            var provider = new ContactProvider();
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

            var provider = new ContactProvider();
            var contact = provider.Retrieve(4);

            Assert.IsNotNull(contact);

        }
    }
}
