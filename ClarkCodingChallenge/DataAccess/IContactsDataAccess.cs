using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.DataAccess
{
    public interface IContactsDataAccess
    {
        List<ContactsModel> GetContacts(string lastName, string order);
        bool CreateContact(ContactsModel contact);
    }
}
