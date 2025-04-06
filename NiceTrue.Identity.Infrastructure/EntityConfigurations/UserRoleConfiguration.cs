using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NiceTrue.Identity.Domain;

namespace NiceTrue.Identity.Infrastructure.EntityConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(_ => new { _.UserId, _.RoleId });
        
        //select * from UserROles Where UserId=1 and RoleId-2 -> 100%
        
    
        builder.HasKey(_ => new {  });
        //select * from UserROles Where UserId=1 and RoleId-2 -> 0%
        
        builder.HasKey(_ => new { _.UserId, _.RoleId });
        //select * from UserROles Where UserId=1 -> 50% 
        
        
        builder.HasKey(_ => new { _.UserId, _.RoleId });
        //select * from UserROles Where Role=1 -> 0%
        
    }
}