using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities;

namespace Portfolio.Data.Configurations;

public class LabWorkConfiguration : IEntityTypeConfiguration<LabWork>
{
    public void Configure(EntityTypeBuilder<LabWork> builder)
    {
        builder.HasMany(c => c.Users)
            .WithMany(c => c.LabWorks)
            ;
    }
}
