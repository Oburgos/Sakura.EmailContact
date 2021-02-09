using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sakura.EmailContact.Features.Common;
using Sakura.EmailContact.Features.Contacts.Dtos;

namespace Sakura.EmailContact.Features.Contacts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController: ControllerBase
    {
        public ContactsController()
        {
        }

        [HttpPost]
        public ActionResult<ContactDto> Create([FromBody] AddContactDto contactDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //return new ContactDto();
        }
    }
}
