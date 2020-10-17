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
        public DbSet<GeneralInfoTag> GeneralInfoTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GeneralInfoTag>(e =>
            {
                e.HasKey(git => new { git.GeneralInformationId, git.Tag });
            });
        }
    }
}
