using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Entities;

namespace Portfolio.Data.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{

    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
       
    }
}
