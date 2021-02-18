using System.Collections.Generic;

namespace Sakura.EmailContact.Features.Contacts.Dtos
{
    public class ContactListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ContactDto> Contacts { get; set; }
    }
}
