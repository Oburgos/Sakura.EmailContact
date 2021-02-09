using System;
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

    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Email { get; set; }
    }
}
