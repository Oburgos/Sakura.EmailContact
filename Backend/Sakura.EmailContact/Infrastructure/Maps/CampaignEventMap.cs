using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakura.EmailContact.Features.Campaigns;

namespace Sakura.EmailContact.Infrastructure.Maps
{
    public class CampaignEventMap : BaseMap<CampaignEvent>
    {
        public CampaignEventMap() : base("CampaignEvents")
        {
        }

        protected override void ConfigureEntity(EntityTypeBuilder<CampaignEvent> builder)
        {
            builder.Property(p => p.CampaignId).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.Hour).IsRequired();
            builder.Property(p => p.ScheduleJobId).IsRequired().HasMaxLength(200);
            builder.HasOne(p => p.Campaign).WithMany(c => c.Events).HasForeignKey(c => c.CampaignId);
        }
    }
}
