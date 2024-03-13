using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities;

namespace Portfolio.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasMany<LabWork>(c => c.LabWorks)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId)
                .IsRequired(false);
    }
}
