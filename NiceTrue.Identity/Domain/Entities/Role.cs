using NiceTrue.Identity.Domain.Enums;

namespace NiceTrue.Identity.Domain.Entities;

public class Role
{
    private Role(string name,int companyId)
    {
        Name = name;
        CompanyId = companyId;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public Permission Permissions { get; set; }
    public int CompanyId { get;private set; }

    public static Role Create(string name,int companyId)
        => new Role(name, companyId);
}