using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakura.EmailContact.Features.Contacts;

namespace Sakura.EmailContact.Infrastructure.Maps
{
    public class ContactMap : BaseMap<Contact>
    {
        public ContactMap() : base("Contacts")
        {
        }

        protected override void ConfigureEntity(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(250).IsRequired();
        }
    }
}
