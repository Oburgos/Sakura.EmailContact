using System;
using Microsoft.EntityFrameworkCore;

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
        }
    }
}
