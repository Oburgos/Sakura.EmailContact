using System;
using System.Threading.Tasks;
using Sakura.EmailContact.Features.Common;
using Sakura.EmailContact.Features.Contacts.Dtos;
using Sakura.EmailContact.Infrastructure.Core;

namespace Sakura.EmailContact.Features.Contacts
{
    public class ContactsAppService
    {
        private readonly IUnitOfWork unitOfWork;

        public ContactsAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<EntityResponse<ContactDto>> CreateContactAsync(AddContactDto newContactDto)
        {
            var result = ModelValidator.Validate(newContactDto, "E0001").As<ContactDto>();
            if (!result.Ok)
            {
                return result;
            }

            Contact contact = newContactDto.CreateEntity();
            await unitOfWork.GetRepository<Contact>().AddAsync(contact);
            await unitOfWork.SaveChangesAsync();
            ContactDto dto = new ContactDto
            {
                Email = contact.Email,
                Id = contact.Id,
                Name = contact.Name
            };
            return EntityResponse.CreateOk().As(dto);
        }
    }
}
