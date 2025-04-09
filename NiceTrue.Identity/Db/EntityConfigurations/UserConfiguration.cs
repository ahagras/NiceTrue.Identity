using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NiceTrue.Identity.Domain.Entities;

namespace NiceTrue.Identity.Db.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Email).HasMaxLength(50);
        builder.Property(u => u.Password).HasMaxLength(70);
        builder.Property(u => u.Name).HasMaxLength(40);
    }
}