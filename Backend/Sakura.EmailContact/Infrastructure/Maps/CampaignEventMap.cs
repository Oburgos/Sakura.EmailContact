using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakura.EmailContact.Features.Campaigns;

namespace Sakura.EmailContact.Infrastructure.Maps
{
    public class CampaignEventMap : BaseMap<CampaignEvent>
    {
        public CampaignEventMap() : base("Campaigns")
        {
        }

        protected override void ConfigureEntity(EntityTypeBuilder<CampaignEvent> builder)
        {
            builder.Property(p => p.CampaignId).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.HasOne(p => p.Campaign).WithMany(c => c.Events).HasForeignKey(c => c.CampaignId);
        }
    }
}
