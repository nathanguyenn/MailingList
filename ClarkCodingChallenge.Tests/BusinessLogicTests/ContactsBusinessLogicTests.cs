using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ClarkCodingChallenge.Tests.BusinessLogicTests
{
    [TestClass]
    public class ContactsBusinessLogicTests
    {
        static List<ContactsModel> _contacts = new List<ContactsModel>();
        static ContactsDataAccess DAL = new ContactsDataAccess(_contacts);
        private IContactService _contactService = new ContactsService(DAL);
        [TestMethod]
        public void TestCreateContact()
        {
            // set up
            var data = new ContactsModel() { FirstName = "fName", LastName = "lName", Email = "test@gmail.com"};

            // execute
            var result = _contactService.CreateContact(data);

            //assert
            Assert.IsTrue(result);
            
        }

        [TestMethod]
        public void TestGetAllContacts()
        {
            // set up
            var lastName = "";
            var order = "Ascending";
            _contacts.Add(new ContactsModel() { FirstName = "first name", LastName = "last name", Email = "email@gmail.com"});
            // execute
            var result = _contactService.GetContacts(lastName, order);
            // assert
            Assert.AreEqual(DAL.Contacts.Count, result.Count);
        }

        [TestMethod]
        public void TestGetContacts()
        {
            // set up
            List<ContactsModel> _contacts = new List<ContactsModel>();
            _contacts.Add(new ContactsModel() { FirstName = "TestGetContacts", LastName = "TestGetContacts", Email = "TestGetContacts@gmail.com" });
            ContactsDataAccess DAL = new ContactsDataAccess(_contacts);
            IContactService _contactService = new ContactsService(DAL);
            
            var lastName = "TestGetContacts";
            var order = "Ascending";
            
            // execute
            var result = _contactService.GetContacts(lastName, order);

            // assert
            Assert.AreNotEqual(0, result.Count);
            Assert.AreEqual(lastName, result[0].LastName);
        }
        [TestMethod]
        public void TestGetContacts2()
        {
            // set up
            string lastname1 = "a";
            string lastname2 = "z";
            List<ContactsModel> _contacts = new List<ContactsModel>();
            _contacts.Add(new ContactsModel() { FirstName = "b", LastName = lastname1, Email = "TestGetContacts@gmail.com" });
            _contacts.Add(new ContactsModel() { FirstName = "a", LastName = lastname1, Email = "TestGetContacts@gmail.com" });
            _contacts.Add(new ContactsModel() { FirstName = "z", LastName = lastname2, Email = "TestGetContacts@gmail.com" });
            ContactsDataAccess DAL = new ContactsDataAccess(_contacts);
            IContactService _contactService = new ContactsService(DAL);
            
            var lastName = "";
            var order = "Ascending";

            // execute
            var result = _contactService.GetContacts(lastName, order);
            // assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(lastname1, result[0].LastName);
            Assert.AreEqual(lastname1, result[1].LastName);
            Assert.AreEqual(lastname2, result[2].LastName);
        }
    }
}
