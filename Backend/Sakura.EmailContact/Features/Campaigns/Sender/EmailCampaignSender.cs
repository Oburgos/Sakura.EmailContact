using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sakura.EmailContact.Features.BackgroudJobs;
using Sakura.EmailContact.Infrastructure.Core;

namespace Sakura.EmailContact.Features.Campaigns.Sender
{

    public class EmailCampaignSender
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly AmazonSimpleEmailServiceClient _awsSes;

        public EmailCampaignSender(IUnitOfWork unitOfWork, IBackgroundJobManager backgroundJobManager, AmazonSimpleEmailServiceClient awsSes)
        {
            this._unitOfWork = unitOfWork;
            this._backgroundJobManager = backgroundJobManager;
            this._awsSes = awsSes;
        }


        public async Task SendCampaign(int campaignId)
        {
            var campaignData = await (from c in _unitOfWork.GetRepository<Campaign>().AsQueryable()
                                where c.Id == campaignId
                                select new BulkEmailCampaignSendRequest
                                {
                                    EmailTemplateId = c.EmailTemplate.AwsTemplateId,
                                    Contacts = (from cl in c.ContactLists
                                                from co in cl.Contacts
                                                where co.Active && cl.Active
                                                select new BulkEmailCampaignContact
                                                {
                                                    Name = co.Name,
                                                    Email = co.Email,
                                                }).ToList()
                                }).FirstAsync();

            campaignData.Contacts = campaignData.Contacts.Distinct().ToList();

            while (campaignData.Contacts.Any())
            {
                var top = campaignData.Contacts.Take(50).ToList();
                var data = new BulkEmailCampaignSendRequest
                {
                    Contacts = top,
                    EmailTemplateId = campaignData.EmailTemplateId
                };

                _backgroundJobManager.Enqueue<EmailCampaignSender>(e => e.SendEmail(data));

                campaignData.Contacts.RemoveRange(0, top.Count);
            }
        }

        public async Task SendEmail(BulkEmailCampaignSendRequest bulkEmail)
        {
            var request = new SendBulkTemplatedEmailRequest
            {
                Source = Environment.GetEnvironmentVariable("AWS_SES_EMAIL_ACCOUNT"),
                Template = bulkEmail.EmailTemplateId,
                DefaultTemplateData = JsonConvert.SerializeObject(new { name = "user" }),
                Destinations = new List<BulkEmailDestination>()
            };

            foreach (var item in bulkEmail.Contacts)
            {
                var templateData = new { name = item.Name };
                request.Destinations.Add(new BulkEmailDestination {
                     ReplacementTemplateData = JsonConvert.SerializeObject(templateData),
                     Destination = new Destination
                     {
                          ToAddresses = new List<string>
                          {
                              item.Email
                          }
                     }
                });
            }
            await _awsSes.SendBulkTemplatedEmailAsync(request);
        }
    }
}
