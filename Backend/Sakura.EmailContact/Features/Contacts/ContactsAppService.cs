using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sakura.EmailContact.Features.Common;
using Sakura.EmailContact.Features.Contacts.Dtos;
using Sakura.EmailContact.Infrastructure.Core;

namespace Sakura.EmailContact.Features.Contacts
{
    public class ContactsAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IRepository<Contact> _contactRepository;
        private readonly IRepository<ContactList> _contactListRepository;

        public ContactsAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this._contactRepository = unitOfWork.GetRepository<Contact>();
            this._contactListRepository = unitOfWork.GetRepository<ContactList>();
        }

        public async Task<EntityResponse<ContactDto>> CreateContactAsync(AddContactDto newContactDto)
        {
            var result = ModelValidator.ValidateAsEntityValidation(newContactDto, "E0001").As<ContactDto>();
            if (!result.Ok)
            {
                return result;
            }

            Contact contact = newContactDto.CreateEntity();
            await _contactRepository.AddAsync(contact);
            await unitOfWork.SaveChangesAsync();
            ContactDto dto = new ContactDto
            {
                Email = contact.Email,
                Id = contact.Id,
                Name = contact.Name
            };
            return EntityResponse.CreateOk().As(dto);
        }

        public async Task<EntityResponse<ContactListDto>> CreateContactListAsync(AddContactListDto newContactListDto)
        {
            var result = ModelValidator.ValidateAsEntityValidation(newContactListDto, "E0002").As<ContactListDto>();
            if (!result.Ok)
            {
                return result;
            }

            List<Contact> contacts = await _contactRepository.AsQueryable().Where(e => newContactListDto.ContactIds.Contains(e.Id)).ToListAsync();
            ContactList list = new ContactList
            {
                Name = newContactListDto.Name,
                Contacts = contacts
            };

            await unitOfWork.GetRepository<ContactList>().AddAsync(list);
            await unitOfWork.SaveChangesAsync();

            return EntityResponse.CreateOk().As(mapper.Map<ContactListDto>(list));
        }

        public async Task<EntityResponse<ContactListDto>> AddContactToListAsync(int listId, List<int> contactsId)
        {
            ContactList list = await _contactListRepository.AsQueryable().FirstOrDefaultAsync(e => e.Id == listId);
            if (list == null)
            {
                return EntityResponse.CreateError("The list doesn't exists", "E0003").As<ContactListDto>();
            }

            List<Contact> contacts = (from c in _contactRepository.AsQueryable()
                                      where contactsId.Contains(c.Id) &&
                                            !c.Lists.Any(l => l.Id == listId)
                                      select c).ToList();

            list.Contacts.AddRange(contacts);
            
            await unitOfWork.SaveChangesAsync();
            var dto = await GetContactListAsync(listId);
            return EntityResponse.CreateOk().As(dto);
        }

        public async Task<List<ContactDto>> GetContactsAsync()
        {
            var response = await (from c in _contactRepository.AsQueryable()
                                  select new ContactDto
                                  {
                                      Id = c.Id,
                                      Name = c.Name,
                                      Email = c.Email
                                  }).ToListAsync();
            return response;
        }

        public async Task<ContactListDto> GetContactListAsync(int listId)
        {
            var response = await (from list in _contactListRepository.AsQueryable()
                            where list.Id == listId
                            select new ContactListDto
                            {
                                Id = list.Id,
                                Name = list.Name,
                                Contacts = (from c in list.Contacts
                                            select new ContactDto
                                            {
                                                Id = c.Id,
                                                Name = c.Name,
                                                Email = c.Email
                                            }).ToList()
                            }).FirstOrDefaultAsync();
            return response;
        }
    }
}
