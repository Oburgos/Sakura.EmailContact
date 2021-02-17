using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sakura.EmailContact.Features.Campaigns;
using Sakura.EmailContact.Features.Campaigns.Dtos;
using Sakura.EmailContact.Features.Common;
using Sakura.EmailContact.Features.Contacts;
using Sakura.EmailContact.Infrastructure.Core;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sakura.EmailContact.Tests
{
    [TestClass]
    public class CampaignTests
    {
        public CampaignTests()
        {
        }

        CampaignAppService BuildAppService()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repository = new Mock<IRepository<Contact>>();
            unitOfWork.Setup(e => e.GetRepository<Contact>()).Returns(repository.Object);
            return new CampaignAppService();
        }

        [TestMethod]
        public void Campaign_ValidateModel()
        {
            var appService = BuildAppService();
            var dto = new AddCampaignDto()
            {
                Name = "",
                EmailTemplateId = 1
            };

            List<ValidationResult> result = ModelValidator.Validate<AddCampaignDto>(dto);

            Assert.AreEqual(expected: 3, result.Count);
            Assert.AreEqual(expected: Messages.AddCampaignDtoNameRequired, result.First(v => v.MemberNames.Contains(nameof(AddCampaignDto.Name))).ErrorMessage);
            Assert.AreEqual(expected: Messages.AddCampaignDto_Events_MinimumOneElementRequired, result.First(v => v.MemberNames.Contains(nameof(AddCampaignDto.Events))).ErrorMessage);
            Assert.AreEqual(expected: Messages.AddCampaignDto_ContactLists_MinimumOneElementRequired, result.First(v => v.MemberNames.Contains(nameof(AddCampaignDto.ContactLists))).ErrorMessage);

            dto.Name = string.Join("", Enumerable.Range(0, 200).Select(e => e.ToString()));
            result = ModelValidator.Validate<AddCampaignDto>(dto);

            Assert.AreEqual(expected: Messages.AddCampaignDtoNameMaxLength, result.First(v => v.MemberNames.Contains(nameof(AddCampaignDto.Name))).ErrorMessage);

            dto.Name = "123";
            result = ModelValidator.Validate<AddCampaignDto>(dto);
            Assert.AreEqual(expected: Messages.AddCampaignDtoNameMinLength, result.First(v => v.MemberNames.Contains(nameof(AddCampaignDto.Name))).ErrorMessage);
        }


        [TestMethod]
        public async Task Campaign_Create_ValidateModel()
        {
            var appService = BuildAppService();
            var newCampaignDto = new AddCampaignDto()
            {
                Name = "",
                EmailTemplateId = 1
            };

            EntityResponse response =  await appService.CreateCampaignAsync(newCampaignDto);
            Assert.AreEqual(expected: false, response.Ok);
            Assert.IsInstanceOfType(response.ErrorData, typeof(List<ValidationResult>));
        }
    }
}
