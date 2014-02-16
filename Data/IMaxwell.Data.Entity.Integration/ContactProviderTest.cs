using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMaxwell.Data.Entity.Integration
{
    [TestClass]
    public class ContactProviderTest
    {
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
