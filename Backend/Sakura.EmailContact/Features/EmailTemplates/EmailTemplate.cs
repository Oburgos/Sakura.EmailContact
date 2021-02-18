using System;
using System.Collections.Generic;
using Sakura.EmailContact.Features.Campaigns;
using Sakura.EmailContact.Features.Common;

namespace Sakura.EmailContact.Features.EmailTemplates
{
    public class EmailTemplate: BaseEntity
    {
        public EmailTemplate()
        {
        }

        public string Name { get; set; }
        public string AwsTemplateId { get; set; }
        public string Body { get; set; }
        public List<Campaign> Campaigns { get; set; } = new List<Campaign>();
    }
}
