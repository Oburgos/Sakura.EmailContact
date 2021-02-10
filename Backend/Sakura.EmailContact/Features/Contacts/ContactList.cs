using System.Collections.Generic;
using Sakura.EmailContact.Features.Campaigns;
using Sakura.EmailContact.Features.Common;

namespace Sakura.EmailContact.Features.Contacts
{
    public class ContactList : BaseEntity
    {
        public ContactList()
        {
        }

        public string Name { get; set; }
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<Campaign> Campaigns { get; set; } = new List<Campaign>();
    }


}
