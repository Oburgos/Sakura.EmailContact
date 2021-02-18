using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sakura.EmailContact.Features.Campaigns.Dtos;

namespace Sakura.EmailContact.Features.Campaigns
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly CampaignAppService _campaignAppService;
        public CampaignsController(CampaignAppService campaignAppService)
        {
            this._campaignAppService = campaignAppService;
        }

        [HttpPost]
        public async Task<ActionResult<CampaignDto>> CreateAsync([FromBody] AddCampaignDto newCampaign)
        {
            var result = await _campaignAppService.CreateCampaignAsync(newCampaign);
            if (!result.Ok)
            {
                return BadRequest(result);
            }
            return result.Data;
        }

    }
}
