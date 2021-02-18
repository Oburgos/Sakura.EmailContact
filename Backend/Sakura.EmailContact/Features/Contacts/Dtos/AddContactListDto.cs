using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sakura.EmailContact.Features.Contacts.Dtos
{
    public class AddContactListDto
    {

        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
        public List<int> ContactIds { get; set; }
    }
}
