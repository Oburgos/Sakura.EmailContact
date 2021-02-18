using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sakura.EmailContact.Features.Common.Annotations;
using Sakura.EmailContact.Features.Contacts.Dtos;

namespace Sakura.EmailContact.Features.Campaigns.Dtos
{

    public class AddCampaignDto
    {
        public AddCampaignDto()
        {
        }

        [Required(ErrorMessage = Messages.AddCampaignDtoNameRequired),
         MaxLength(150,ErrorMessage = Messages.AddCampaignDtoNameMaxLength),
         MinLength(4, ErrorMessage = Messages.AddCampaignDtoNameMinLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email template is required")]
        public int EmailTemplateId { get; set; }

        [MinimumOneElementRequired(ErrorMessage = Messages.AddCampaignDto_Events_MinimumOneElementRequired)]
        public List<AddEventDto> Events { get; set; } = new List<AddEventDto>();

        [MinimumOneElementRequired(ErrorMessage = Messages.AddCampaignDto_ContactLists_MinimumOneElementRequired)]
        public List<int> ContactLists { get; set; } = new List<int>();


        public Campaign CreateEntity()
        {
            var campaign = new Campaign
            {
                Name = Name,
                EmailTemplateId = EmailTemplateId,
            };

            foreach (var @event in Events)
            {
                campaign.AddEvent(@event.Date);
            }
            return campaign;
        }
    }

    public class CampaignDto
    {
        public CampaignDto()
        {
        }

        public int Id { get; internal set; }
        public string Name { get; set; }
        public List<EventDto> Events { get; set; } = new List<EventDto>();
        public List<ContactListDto> ContactLists { get; set; } = new List<ContactListDto>();
    }
}
