using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.BusinessLogic
{
    public interface IContactService
    {
        List<ContactsModel> GetContacts(string lastname, string order);
        bool CreateContact(ContactsModel contact);
    }
}
