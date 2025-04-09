using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NiceTrue.Identity.Domain.Entities;

namespace NiceTrue.Identity.Db.EntityConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });
        builder.HasIndex(ur => ur.UserId);
        builder.HasKey(ur => ur.RoleId);
    }
}