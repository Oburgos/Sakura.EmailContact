using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sakura.EmailContact.Features.Common;
using Sakura.EmailContact.Features.Contacts;
using Sakura.EmailContact.Features.Contacts.Dtos;
using Sakura.EmailContact.Infrastructure.Core;

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
            var unitOfWork = new Mock<IUnitOfWork>();
            var repository = new Mock<IRepository<Contact>>();
            unitOfWork.Setup(e => e.GetRepository<Contact>()).Returns(repository.Object);
            var appService = new ContactsAppService(unitOfWork.Object);
            var createDto = new AddContactDto();

            //Act
            var result = appService.CreateContactAsync(createDto).GetAwaiter().GetResult();

            createDto.Name = "Omar";
            var result2 = appService.CreateContactAsync(createDto).GetAwaiter().GetResult();

            //Assert
            Assert.AreEqual(expected: false, result.Ok);
            Assert.AreEqual(expected: "E0001", result.MessageCode);
            Assert.AreEqual(expected: "The name is required", result.Message);
            Assert.AreEqual(expected: "The email is required", result2.Message);
        }
    }
}
