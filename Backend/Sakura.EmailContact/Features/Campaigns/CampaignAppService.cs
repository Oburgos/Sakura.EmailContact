using System;
using System.Threading.Tasks;
using Sakura.EmailContact.Features.Campaigns.Dtos;
using Sakura.EmailContact.Features.Common;

namespace Sakura.EmailContact.Features.Campaigns
{
    public class CampaignAppService
    {
        public CampaignAppService()
        {
        }

        public async Task<EntityResponse> CreateCampaignAsync(AddCampaignDto newCampaignDto)
        {
            var modelValidationResult = ModelValidator.ValidateAsEntityValidation(newCampaignDto, "ECACC-01");
            if (!modelValidationResult.Ok)
            {
                return modelValidationResult;
            }
            return modelValidationResult;
        }
    }
}
