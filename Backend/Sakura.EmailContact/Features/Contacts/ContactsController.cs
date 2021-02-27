using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sakura.EmailContact.Features.Common;
using Sakura.EmailContact.Features.Contacts.Dtos;

namespace Sakura.EmailContact.Features.Contacts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController: ControllerBase
    {
        private readonly ContactsAppService _contactsAppService;

        public ContactsController(ContactsAppService contactsAppService)
        {
            this._contactsAppService = contactsAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ContactDto>> CreateAsync([FromBody] AddContactDto contactDto)
        {
            var result = await _contactsAppService.CreateContactAsync(contactDto);
            if (!result.Ok)
            {
                return BadRequest(result);
            }
            return result.Data;
        }

       

        [HttpGet("")]
        public async Task<ActionResult<List<ContactDto>>> GetContactsAsync()
        {
            List<ContactDto> result = await _contactsAppService.GetContactsAsync();
            return result;
        }

        [HttpPost("lists")]
        public async Task<ActionResult<ContactListDto>> CreateListAsync([FromBody] AddContactListDto contactDto)
        {
            var result = await _contactsAppService.CreateContactListAsync(contactDto);
            if (!result.Ok)
            {
                return BadRequest(result);
            }
            return result.Data;
        }

        [HttpPost("lists/{listId}/contacts")]
        public async Task<ActionResult<ContactListDto>> AddContactToListAsync(int listId, [FromBody] List<int> contactsId)
        {
            var result = await _contactsAppService.AddContactToListAsync(listId, contactsId);
            if (!result.Ok)
            {
                return BadRequest(result);
            }
            return result.Data;
        }

        [HttpGet("lists/{id}")]
        public async Task<ActionResult<ContactListDto>> GetContactListAsync(int id)
        {
            var result = await _contactsAppService.GetContactListAsync(id);
            return result;
        }

        [HttpGet("lists")]
        public async Task<ActionResult<List<ContactListDto>>> GetContactListsAsync()
        {
            var result = await _contactsAppService.GetContactListsAsync();
            return result;
        }
    }
}
