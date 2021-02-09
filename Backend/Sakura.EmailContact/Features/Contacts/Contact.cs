using System;
using System.Collections.Generic;
using Sakura.EmailContact.Features.Common;

namespace Sakura.EmailContact.Features.Contacts
{
    public class Contact: BaseEntity
    {
        public Contact()
        {
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public List<ContactList> Lists { get; set; }
    }
}
