using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakura.EmailContact.Features.Contacts;

namespace Sakura.EmailContact.Infrastructure.Maps
{
    public class ContactListMap : BaseMap<ContactList>
    {
        public ContactListMap() : base("ContactLists")
        {
        }

        protected override void ConfigureEntity(EntityTypeBuilder<ContactList> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
        }
    }
}
