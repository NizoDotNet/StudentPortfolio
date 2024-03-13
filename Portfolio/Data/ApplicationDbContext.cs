using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Configurations;
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

            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new SubjectConfiguration());

            base.OnModelCreating(builder);

        }
    }
}
