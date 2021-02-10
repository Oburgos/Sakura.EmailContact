using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakura.EmailContact.Features.Campaigns;

namespace Sakura.EmailContact.Infrastructure.Maps
{
    public class CampaignMap : BaseMap<Campaign>
    {
        public CampaignMap() : base("CampaignEvents")
        {
        }

        protected override void ConfigureEntity(EntityTypeBuilder<Campaign> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.HasOne(p => p.EmailTemplate).WithMany(c => c.Campaigns).HasForeignKey(c => c.EmailTemplateId);
        }
    }
}
