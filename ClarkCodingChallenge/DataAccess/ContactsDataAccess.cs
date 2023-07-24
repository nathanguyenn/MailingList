using ClarkCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.DataAccess
{
    public class ContactsDataAccess : IContactsDataAccess
    {

        private List<ContactsModel> _contacts; 
        public List<ContactsModel> Contacts { get { return _contacts; } }
        public string ConnectionString { get; set; }
        public ContactsDataAccess() 
        { _contacts = new List<ContactsModel>(); }
        // for testing
        public ContactsDataAccess(List<ContactsModel> mockDB)
        { _contacts = mockDB; }
        public bool CreateContact(ContactsModel contact)
        {
            _contacts.Add(contact);
            return true;
        }

        public List<ContactsModel> GetContacts(string lastName, string order)
        {
            if (order.Equals("Descending"))
            {
                _contacts = _contacts.OrderByDescending(p => p.LastName).ThenByDescending(p=>p.FirstName).ToList();
            }
            else if (order.Equals("Ascending"))
            {
                _contacts = _contacts.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToList();
            }
            else
            {
                throw new ArgumentException("Order keyword invalid");
            }

            if (lastName.Equals(""))
            {
                return _contacts;
            }
            else
            {
                return _contacts.Where(p => p.LastName == lastName).ToList();
            }
        }
    }
}
