using System;
using Sakura.EmailContact.Features.Common;

namespace Sakura.EmailContact.Features.Campaigns
{
    public class CampaignEvent : BaseEntity
    {
        public CampaignEvent()
        {
        }

        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }

        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}
