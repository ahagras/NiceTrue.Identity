using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NiceTrue.Identity.Domain.Entities;

namespace NiceTrue.Identity.Db.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasIndex(r => r.CompanyId);
        builder.Property(r => r.Name).HasMaxLength(22);
    }
}