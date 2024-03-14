using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities;

namespace Portfolio.Data.Configurations;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {

        builder
            .HasMany(c => c.Students)
            .WithMany(c => c.Classes);

        builder
            .HasMany(c => c.Subjects)
            .WithMany(c => c.Classes);
    }
}
