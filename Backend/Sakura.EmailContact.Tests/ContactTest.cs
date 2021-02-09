using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sakura.EmailContact.Features.Common;
using Sakura.EmailContact.Features.Contacts;

namespace Sakura.EmailContact.Tests
{
    [TestClass]
    public class ContactTest
    {

        public ContactTest()
        {
        }

        [TestMethod]
        public void Contacts_ValidateContactInformation()
        {
            //Arrange
            var httpCtx = new Mock<HttpContext>();
            var ctr = new ContactsController();
            ctr.ModelState.Clear();
            ctr.ControllerContext.HttpContext = httpCtx.Object;
            var response = ctr.Create(new Features.Contacts.Dtos.AddContactDto());
            //EntityResponse result = (response.Result as BadRequestObjectResult).Value as EntityResponse;
            BadRequestObjectResult result = (response.Result as BadRequestObjectResult);
        }
    }
}
