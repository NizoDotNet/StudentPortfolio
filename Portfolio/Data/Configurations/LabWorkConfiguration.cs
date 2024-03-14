using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities;

namespace Portfolio.Data.Configurations;

public class LabWorkConfiguration : IEntityTypeConfiguration<LabWork>
{
    public void Configure(EntityTypeBuilder<LabWork> builder)
    {
        builder.HasOne(c => c.Subject)
                .WithMany(c => c.LabWorks)
                .HasForeignKey(c => c.SubjectId)
                .IsRequired(false);
    }
}
