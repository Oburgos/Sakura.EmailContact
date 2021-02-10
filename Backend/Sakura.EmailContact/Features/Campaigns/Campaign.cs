using System.Collections.Generic;
using Sakura.EmailContact.Features.Common;
using Sakura.EmailContact.Features.Contacts;
using Sakura.EmailContact.Features.EmailTemplates;

namespace Sakura.EmailContact.Features.Campaigns
{
    public class Campaign: BaseEntity
    {
        public Campaign()
        {
        }

        public string Name { get; set; }
        public List<CampaignEvent> Events { get; set; } = new List<CampaignEvent>();

        public int EmailTemplateId { get; set; }
        public EmailTemplate EmailTemplate { get; set; }

        public List<ContactList> ContactLists { get; set; } = new List<ContactList>();
    }
}
