using System;
using Sakura.EmailContact.Features.Common;

namespace Sakura.EmailContact.Features.Contacts
{
    public class ContactsAppService
    {
        public ContactsAppService()
        {
        }

        public EntityResponse CreateContact()
        {

            return EntityResponse.CreateOk();
        }
    }
}
