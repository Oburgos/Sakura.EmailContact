using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<CampaignEvent> Events { get; protected set; } = new List<CampaignEvent>();

        public int EmailTemplateId { get; set; }
        public EmailTemplate EmailTemplate { get; set; }

        public List<ContactList> ContactLists { get; protected set; } = new List<ContactList>();

        public void AddEvent(DateTime date)
        {
            CampaignEvent @event = new CampaignEvent
            {
                Date = date.Date,
                Hour = date,
                ScheduleJobId = ""
            };
            bool exists = Events.Any(e => e.Date == @event.Date && e.Hour == @event.Hour);
            if (exists)
            {
                return;
            }
            Events.Add(@event);
        }

        public void AddList(List<ContactList> lists)
        {
            lists = lists.Where(e => !ContactLists.Any(c => c.Id == e.Id)).ToList();
            ContactLists.AddRange(lists);
        }
    }
}
