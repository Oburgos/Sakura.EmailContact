using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sakura.EmailContact.Features.Contacts.Dtos
{
    public class AddContactDto
    {
        public AddContactDto()
        {
        }

        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email is required"), EmailAddress(ErrorMessage = "The email format is incorrect")]
        public string Email { get; set; }

        public Contact CreateEntity()
        {
            return new Contact
            {
                Email = Email,
                Name = Name
            };
        }
    }

    public class AddContactListDto
    {

        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
        public List<int> ContactIds { get; set; }
    }

    public class ContactListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ContactDto> Contacts { get; set; }
    }
}
