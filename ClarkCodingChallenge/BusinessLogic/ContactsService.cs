using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.BusinessLogic
{
    public class ContactsService : IContactService
    {
        private IContactsDataAccess _contactsDataAccess;
        public ContactsService(IContactsDataAccess contactDA) 
        {
            _contactsDataAccess = contactDA;
        }
        public bool CreateContact(ContactsModel contact)
        {
            return _contactsDataAccess.CreateContact(contact);
        }

        public List<ContactsModel> GetContacts(string lastname, string order)
        {
            return _contactsDataAccess.GetContacts(lastname, order);
        }
    }
}
