using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities;

namespace Portfolio.Data.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{

    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder
               .HasMany(c => c.Subjects)
               .WithOne(c => c.Teacher)
               .HasForeignKey(c => c.TeacherId)
               .IsRequired(false);

        builder
            .HasMany(c => c.Classes)
            .WithOne(c => c.Teacher)
            .HasForeignKey(c => c.TeacherId)
            .IsRequired(false);
    }
}
