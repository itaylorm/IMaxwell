using System;
using System.Data;
using IMaxwell.Data.Core;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IMaxwell.Data.Sql.Test
{
    /// <summary>
    /// Ensure that Sql based ContactProvider methods function correctly
    /// </summary>
    [TestClass]
    public class ContactProviderTest
    {

        /// <summary>
        /// Ensure that a single contact retrieved from the mock query provider is returned 
        /// and no data is lost
        /// </summary>
        [TestMethod]
        public void RetrieveContactTest()
        {
            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);
            var contactProvider = new ContactProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ContactID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("MiddleName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("LastName", typeof(string)));

            var taylorRow = dataTable.NewRow();
            taylorRow["ContactID"] = 1;
            taylorRow["FirstName"] = "Taylor";
            taylorRow["MiddleName"] = "H";
            taylorRow["LastName"] = "Maxwell";
            dataTable.Rows.Add(taylorRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var contact = contactProvider.Retrieve(1);

            Assert.IsNotNull(contact);
            ;
            Assert.AreEqual(taylorRow["ContactID"], contact.Id);
            Assert.AreEqual(taylorRow["FirstName"], contact.FirstName);
            Assert.AreEqual(taylorRow["MiddleName"], contact.MiddleName);
            Assert.AreEqual(taylorRow["LastName"], contact.LastName);

        }

        /// <summary>
        /// Ensure that contacts retrieved from the mock query provider is returned
        /// appropriately without losing data
        /// </summary>
        [TestMethod]
        public void RetrieveContactsTest()
        {
            var queryProvider = new Mock<Core.IQueryProvider>(MockBehavior.Strict);

            var contactProvider = new ContactProvider(queryProvider.Object);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ContactID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("MiddleName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("LastName", typeof(string)));

            var taylorRow = dataTable.NewRow();
            taylorRow["ContactID"] = 1;
            taylorRow["FirstName"] = "Taylor";
            taylorRow["MiddleName"] = "H";
            taylorRow["LastName"] = "Maxwell";
            dataTable.Rows.Add(taylorRow);

            var marciaRow = dataTable.NewRow();
            marciaRow["ContactID"] = 2;
            marciaRow["FirstName"] = "Marcia";
            marciaRow["MiddleName"] = "L";
            marciaRow["LastName"] = "Maxwell";
            dataTable.Rows.Add(marciaRow);

            var robynRow = dataTable.NewRow();
            robynRow["ContactID"] = 3;
            robynRow["FirstName"] = "Robyn";
            robynRow["MiddleName"] = "E";
            robynRow["LastName"] = "Maxwell";
            dataTable.Rows.Add(robynRow);

            queryProvider.Setup(q => q.RetrieveData(It.IsAny<string>())).Returns(dataTable).Verifiable("RetrieveData was not called");

            var contacts = contactProvider.Retrieve().ToList();

            Assert.IsNotNull(contacts);
            Assert.AreEqual(3, contacts.Count());

            var contactTaylor = contacts.ElementAt(0);
            Assert.AreEqual(taylorRow["ContactID"], contactTaylor.Id);
            Assert.AreEqual(taylorRow["FirstName"], contactTaylor.FirstName);
            Assert.AreEqual(taylorRow["MiddleName"], contactTaylor.MiddleName);
            Assert.AreEqual(taylorRow["LastName"], contactTaylor.LastName);

            var contactMarcia = contacts.ElementAt(1);
            Assert.AreEqual(marciaRow["ContactID"], contactMarcia.Id);
            Assert.AreEqual(marciaRow["FirstName"], contactMarcia.FirstName);
            Assert.AreEqual(marciaRow["MiddleName"], contactMarcia.MiddleName);
            Assert.AreEqual(marciaRow["LastName"], contactMarcia.LastName);

            var contactRobyn = contacts.ElementAt(2);
            Assert.AreEqual(robynRow["ContactID"], contactRobyn.Id);
            Assert.AreEqual(robynRow["FirstName"], contactRobyn.FirstName);
            Assert.AreEqual(robynRow["MiddleName"], contactRobyn.MiddleName);
            Assert.AreEqual(robynRow["LastName"], contactRobyn.LastName);

        }

    }
}
