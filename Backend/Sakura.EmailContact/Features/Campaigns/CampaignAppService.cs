using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sakura.EmailContact.Features.BackgroudJobs;
using Sakura.EmailContact.Features.Campaigns.Dtos;
using Sakura.EmailContact.Features.Campaigns.Sender;
using Sakura.EmailContact.Features.Common;
using Sakura.EmailContact.Features.Contacts;
using Sakura.EmailContact.Features.Contacts.Dtos;
using Sakura.EmailContact.Infrastructure.Core;

namespace Sakura.EmailContact.Features.Campaigns
{
    public class CampaignAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBackgroundJobManager _backgroundJobManager;

        public CampaignAppService(IUnitOfWork unitOfWork, IBackgroundJobManager backgroundJobManager)
        {
            this._unitOfWork = unitOfWork;
            this._backgroundJobManager = backgroundJobManager;
        }

        public async Task<EntityResponse<CampaignDto>> CreateCampaignAsync(AddCampaignDto newCampaignDto)
        {
            var modelValidationResult = ModelValidator.ValidateAsEntityValidation(newCampaignDto, "ECACC-01");
            if (!modelValidationResult.Ok)
            {
                return modelValidationResult.As<CampaignDto>();
            }

            Campaign campaign = newCampaignDto.CreateEntity();
            List<ContactList> lists = _unitOfWork.GetRepository<ContactList>().AsQueryable().Where(c => newCampaignDto.ContactLists.Contains(c.Id)).ToList();
            campaign.AddList(lists);


            await _unitOfWork.GetRepository<Campaign>().AddAsync(campaign);
            await _unitOfWork.SaveChangesAsync();

            campaign.Events.ForEach(e =>
            {
                e.ScheduleJobId = _backgroundJobManager.Schedule<EmailCampaignSender>(s => s.SendCampaign(campaign.Id), e.Hour);
            });
           

            var dto = (from c in _unitOfWork.GetRepository<Campaign>().AsQueryable()
                       where c.Id == campaign.Id
                       select new CampaignDto
                       {
                           Id = c.Id,
                           Name = c.Name,
                           Events = (from e in c.Events
                                    select new EventDto
                                    {
                                       ScheduleJobId = e.ScheduleJobId,
                                        Date = e.Date,
                                        Hour = e.Hour
                                    }).ToList(),
                           ContactLists = (from l in c.ContactLists
                                           select new ContactListDto
                                           {
                                               Id = l.Id,
                                               Name = l.Name,
                                           }).ToList()
                       }).First();

            return EntityResponse.CreateOk().As(dto);
        }
    }
}
