using System.Collections.Generic;
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
    public class ContactProviderTest
    {

        /// <summary>
        /// Ensure that contacts retrieved from the mock entity framework is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveContactsTest()
        {

            var data = new List<Contact> 
            { 
                new Contact { ContactID=1, FirstName = "Taylor", MiddleName ="H", LastName = "Maxwell"}, 
                new Contact { ContactID=2, FirstName = "Marcia", MiddleName = "L", LastName = "Maxwell"}, 
                new Contact { ContactID=3, FirstName = "Robyn", MiddleName = "E", LastName = "Maxwell"}, 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Contact>>();
            mockSet.As<IQueryable<Contact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Contact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Contact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Contact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.Contacts).Returns(mockSet.Object);

            var provider = new ContactProvider(mockContext.Object);

            var contacts = provider.Retrieve().ToList();

            Assert.IsNotNull(contacts);
            Assert.AreEqual(3, contacts.Count());

            var contactTaylor = contacts.ElementAt(0);
            Assert.AreEqual(1, contactTaylor.Id);
            Assert.AreEqual("Taylor", contactTaylor.FirstName);
            Assert.AreEqual("H", contactTaylor.MiddleName);
            Assert.AreEqual("Maxwell", contactTaylor.LastName);

            var contactMarcia = contacts.ElementAt(1);
            Assert.AreEqual(2, contactMarcia.Id);
            Assert.AreEqual("Marcia", contactMarcia.FirstName);
            Assert.AreEqual("L", contactMarcia.MiddleName);
            Assert.AreEqual("Maxwell", contactMarcia.LastName);

            var contactRobyn = contacts.ElementAt(2);
            Assert.AreEqual(3, contactRobyn.Id);
            Assert.AreEqual("Robyn", contactRobyn.FirstName);
            Assert.AreEqual("E", contactRobyn.MiddleName);
            Assert.AreEqual("Maxwell", contactRobyn.LastName);


        }

        /// <summary>
        /// Ensure that contact retrieved from the mock entity framework is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveContactTest()
        {

            var data = new List<Contact> 
            { 
                new Contact { ContactID=1, FirstName = "Taylor", MiddleName ="H", LastName = "Maxwell"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Contact>>();
            mockSet.As<IQueryable<Contact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Contact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Contact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Contact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Entities>();
            mockContext.Setup(c => c.Contacts).Returns(mockSet.Object);

            var provider = new ContactProvider(mockContext.Object);

            var contact = provider.Retrieve(1);

            Assert.IsNotNull(contact);

            Assert.AreEqual(1, contact.Id);
            Assert.AreEqual("Taylor", contact.FirstName);
            Assert.AreEqual("H", contact.MiddleName);
            Assert.AreEqual("Maxwell", contact.LastName);

        }
    }
}
