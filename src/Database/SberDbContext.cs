using Microsoft.EntityFrameworkCore;
using Models;
using Models.Links;
using System;

namespace Database
{
    public class SberDbContext : DbContext
    {
        public SberDbContext(DbContextOptions<SberDbContext> options) : base(options)
        {
        }

        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleGeneralInformation> GeneralInformation { get; set; }
        public DbSet<ModuleTag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ModuleTag>(e =>
            {
                e.HasIndex(mt => mt.Value).IsUnique();
            });

            modelBuilder.Entity<GeneralInfoToLink>(e =>
            {
                e.HasKey(gtl => new { gtl.GeneralInformationId, gtl.TagId });
            });
        }
    }
}
