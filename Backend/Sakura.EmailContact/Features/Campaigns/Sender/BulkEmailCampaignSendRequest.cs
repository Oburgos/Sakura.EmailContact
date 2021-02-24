using System.Collections.Generic;

namespace Sakura.EmailContact.Features.Campaigns.Sender
{
    public class BulkEmailCampaignSendRequest
    {
        public string EmailTemplateId { get; set; }
        public List<BulkEmailCampaignContact> Contacts { get; set; }
    }
}
