using System;
using AutoMapper;

namespace Sakura.EmailContact.Features.Contacts.Dtos
{
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            //Entity to dto
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactList, ContactListDto>();
        }
    }
}
