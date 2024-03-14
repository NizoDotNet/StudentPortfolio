using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities;

namespace Portfolio.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasMany(c => c.LabWorks)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId)
                .IsRequired(false);

        builder.HasOne(c => c.Teacher)
            .WithMany(c => c.Subjects)
            .HasForeignKey(c => c.TeacherId)
            .IsRequired(false);
    }
}
