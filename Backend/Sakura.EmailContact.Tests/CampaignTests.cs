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
using System;

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
            var contactListsRepository = new Mock<IRepository<ContactList>>();

            contactListsRepository.Setup(e => e.AsQueryable()).Returns(
                (new List<ContactList>
                {
                    new ContactList
                    {
                         Id = 1,
                         Name = "Gold clients"
                    }
                }).AsQueryable()
                );

            var campaignRepository = new Mock<IRepository<Campaign>>();
            List<Campaign> campaigns = new List<Campaign>();
            campaignRepository.Setup(e => e.AsQueryable()).Returns(campaigns.AsQueryable());
            campaignRepository.Setup(a => a.AddAsync(It.IsAny<Campaign>())).Callback<Campaign>((e) =>
            {
                campaigns.Add(e);
            });

            unitOfWork.Setup(e => e.GetRepository<ContactList>()).Returns(contactListsRepository.Object);
            unitOfWork.Setup(e => e.GetRepository<Campaign>()).Returns(campaignRepository.Object);



            return new CampaignAppService(unitOfWork.Object);
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
            Assert.AreEqual(expected: 3, (response.ErrorData as List<ValidationResult>).Count);
        }

        [TestMethod]
        public void Campaign_Create_ValidateEntity()
        {
            var newCampaignDto = new AddCampaignDto()
            {
                Name = "New 123",
                EmailTemplateId = 1,
                Events = new List<AddEventDto>
                {
                    new AddEventDto
                    {
                         Date = DateTime.Now.AddDays(5)
                    }
                },
                ContactLists = new List<int>
                {
                    1
                }
            };

            var result = newCampaignDto.CreateEntity();
            Assert.AreEqual(expected: newCampaignDto.Events.Count, result.Events.Count);
            Assert.AreEqual(expected: newCampaignDto.Name, result.Name);
            Assert.AreEqual(expected: newCampaignDto.EmailTemplateId, result.EmailTemplateId);
        }

        [TestMethod]
        public async Task Campaign_Create_CreateCampaignAndAddContactList()
        {
            var appService = BuildAppService();
            var newCampaignDto = new AddCampaignDto()
            {
                Name = "New 123",
                EmailTemplateId = 1,
                Events = new List<AddEventDto>
                {
                    new AddEventDto
                    {
                         Date = DateTime.Now.AddDays(5)
                    }
                },
                ContactLists = new List<int>
                {
                    1
                }
            };

            EntityResponse<CampaignDto> result = await appService.CreateCampaignAsync(newCampaignDto);
            Assert.AreEqual(expected: true, result.Ok);
            Assert.AreEqual(expected: 1, result.Data.ContactLists.Count);
            Assert.AreEqual(expected: newCampaignDto.Name, result.Data.Name);
            Assert.AreEqual(expected: 1, result.Data.Events.Count);
            Assert.AreEqual(expected: newCampaignDto.Events.First().Date.Date, result.Data.Events.First().Date);
            Assert.AreEqual(expected: newCampaignDto.Events.First().Date, result.Data.Events.First().Hour);
        }
    }
}
