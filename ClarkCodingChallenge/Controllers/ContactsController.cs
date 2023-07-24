using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using System.Net;
using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.BusinessLogic;
using System;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        private IContactService _contactsService;
        public ContactsController(IContactService service) 
        {
            _contactsService = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult ContactSubmission(ContactsModel data)
        {
            if (string.IsNullOrEmpty(data.FirstName) ||
                string.IsNullOrEmpty(data.LastName) ||
                string.IsNullOrEmpty(data.Email))
            {
                return View("Error",new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            try
            {
                var success = _contactsService.CreateContact(data);
                if (success) { return View("ContactSubmission"); }
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex) { return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
        }
        public IActionResult GetDetails([FromHeader] string lastname= "", [FromHeader] string order = "Descending")
        {
            try
            {
                var result = _contactsService.GetContacts(lastname, order);
                return new OkObjectResult(result);
            }
            catch (ArgumentException ex) { return new BadRequestObjectResult(ex.Message); }
            catch (Exception) { return StatusCode(500); }
        }

    }
}
