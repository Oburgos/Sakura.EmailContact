using System;
using Microsoft.EntityFrameworkCore;
using Sakura.EmailContact.Infrastructure.Maps;

namespace Sakura.EmailContact.Infrastructure
{
    public class EmailContactDbContext: DbContext
    {
        public EmailContactDbContext(DbContextOptions<EmailContactDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new ContactListMap());
            modelBuilder.ApplyConfiguration(new EmailTemplateMap());
            modelBuilder.ApplyConfiguration(new CampaignMap());
            modelBuilder.ApplyConfiguration(new CampaignEventMap());
        }
    }
}
