namespace NiceTrue.Identity.Domain;

public class Role
{
    private Role(string name)
    {
        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public Permission Permissions { get; set; }
    public int CompanyId { get; set; }

    public static Role Create(string name)
        => new Role(name);
}