using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Entities;

namespace Portfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Subject> Subjects { get; set; }
        public DbSet<LabWork> LabWorks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Subject>()
                .HasMany<LabWork>(c => c.LabWorks)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId)
                .IsRequired(false);

            builder.Entity<AppUser>()
                .HasMany(c => c.Subjects)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .IsRequired(false);
        }
    }
}
