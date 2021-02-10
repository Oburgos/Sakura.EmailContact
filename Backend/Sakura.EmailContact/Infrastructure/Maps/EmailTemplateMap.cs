using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakura.EmailContact.Features.EmailTemplates;

namespace Sakura.EmailContact.Infrastructure.Maps
{
    public class EmailTemplateMap : BaseMap<EmailTemplate>
    {
        public EmailTemplateMap() : base("EmailTemplates")
        {
        }

        protected override void ConfigureEntity(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.AwsTemplateId).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Subject).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Body).IsRequired();
        }
    }
}
