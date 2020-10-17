using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Database
{
    public class SberDbContext : DbContext
    {
        public SberDbContext(DbContextOptions<SberDbContext> options) : base(options)
        {
        }

        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleTeacherInstructions> TeacherInstructions { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tag>(e =>
            {
                e.HasKey(git => new { git.ModuleId, git.Value });
            });
        }
    }
}
