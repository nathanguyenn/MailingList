using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.Controllers;
using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClarkCodingChallenge.Tests.ControllerTest
{
    [TestClass]
    public class ContactsControllerTests
    {
        private ContactsController _controller = new ContactsController(null);
        [TestMethod]
        public void TestIndex()
        {
            // execute
            var result = _controller.Index();
            // assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestError()
        {
            //set up
            Activity temp = new Activity("test");
            temp.Start();
            // execute
            var result = _controller.Error();
            // assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(result);
            temp.Stop();
        }
        [TestMethod]
        public void TestContactSubmission()
        {
            //set up
            Activity temp = new Activity("test");
            temp.Start();
            ContactsModel model = new ContactsModel() { FirstName = "fName", LastName = "lName", Email = "test@gmail.com" };
            // execute
            var result = _controller.ContactSubmission(model);
            // assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(result);
            temp.Stop();
        }
        [TestMethod]
        public void TestGetDetailsGoodRequest()
        {
            //set up
            
            List<ContactsModel> _contacts = new List<ContactsModel>();
            _contacts.Add(new ContactsModel() { FirstName = "b", LastName = "test1", Email = "test@gmail.com" });
            _contacts.Add(new ContactsModel() { FirstName = "a", LastName = "test2", Email = "test@gmail.com" });
            _contacts.Add(new ContactsModel() { FirstName = "z", LastName = "test3", Email = "test@gmail.com" });
            ContactsDataAccess DAL = new ContactsDataAccess(_contacts);
            IContactService _contactService = new ContactsService(DAL);
            ContactsController _controller = new ContactsController(_contactService);

            // execute
            var result = _controller.GetDetails("test1");
            // assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetDetailsBadRequest()
        {
            //set up

            List<ContactsModel> _contacts = new List<ContactsModel>();
            _contacts.Add(new ContactsModel() { FirstName = "b", LastName = "test1", Email = "test@gmail.com" });
            _contacts.Add(new ContactsModel() { FirstName = "a", LastName = "test2", Email = "test@gmail.com" });
            _contacts.Add(new ContactsModel() { FirstName = "z", LastName = "test3", Email = "test@gmail.com" });
            ContactsDataAccess DAL = new ContactsDataAccess(_contacts);
            IContactService _contactService = new ContactsService(DAL);
            ContactsController _controller = new ContactsController(_contactService);

            // execute
            var result = _controller.GetDetails("test1", "asdsad");
            // assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsNotNull(result);
        }
    }
}
