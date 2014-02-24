using System;
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
                new Contact { ContactID=1, FirstName = "Taylor", MiddleName ="H", LastName = "Maxwell", ModifiedDate = DateTime.Now }, 
                new Contact { ContactID=2, FirstName = "Marcia", MiddleName = "L", LastName = "Maxwell", ModifiedDate = DateTime.Now }, 
                new Contact { ContactID=3, FirstName = "Robyn", MiddleName = "E", LastName = "Maxwell", ModifiedDate = DateTime.Now }, 
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
            var originalTaylor = data.ElementAt(0);
            Assert.AreEqual(originalTaylor.ContactID, contactTaylor.Id);
            Assert.AreEqual(originalTaylor.FirstName, contactTaylor.FirstName);
            Assert.AreEqual(originalTaylor.MiddleName, contactTaylor.MiddleName);
            Assert.AreEqual(originalTaylor.LastName, contactTaylor.LastName);
            Assert.AreEqual(originalTaylor.ModifiedDate, contactTaylor.ModifiedDate);

            var contactMarcia = contacts.ElementAt(1);
            var originalMarcia = data.ElementAt(1);
            Assert.AreEqual(originalMarcia.ContactID, contactMarcia.Id);
            Assert.AreEqual(originalMarcia.FirstName, contactMarcia.FirstName);
            Assert.AreEqual(originalMarcia.MiddleName, contactMarcia.MiddleName);
            Assert.AreEqual(originalMarcia.LastName, contactMarcia.LastName);
            Assert.AreEqual(originalMarcia.ModifiedDate, contactMarcia.ModifiedDate);

            var contactRobyn = contacts.ElementAt(2);
            var originalRobyn = data.ElementAt(2);
            Assert.AreEqual(originalRobyn.ContactID, contactRobyn.Id);
            Assert.AreEqual(originalRobyn.FirstName, contactRobyn.FirstName);
            Assert.AreEqual(originalRobyn.MiddleName, contactRobyn.MiddleName);
            Assert.AreEqual(originalRobyn.LastName, contactRobyn.LastName);
            Assert.AreEqual(originalRobyn.ModifiedDate, contactRobyn.ModifiedDate);

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
                new Contact { ContactID=1, FirstName = "Taylor", MiddleName ="H", LastName = "Maxwell", ModifiedDate = DateTime.Now}
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

            var originalTaylor = data.ElementAt(0);
            Assert.AreEqual(originalTaylor.ContactID, contact.Id);
            Assert.AreEqual(originalTaylor.FirstName, contact.FirstName);
            Assert.AreEqual(originalTaylor.MiddleName, contact.MiddleName);
            Assert.AreEqual(originalTaylor.LastName, contact.LastName);
            Assert.AreEqual(originalTaylor.ModifiedDate, contact.ModifiedDate);

        }
    }
}
