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
    [ApiController, Authorize]
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
    }
}
