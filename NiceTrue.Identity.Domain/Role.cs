namespace NiceTrue.Identity.Domain;

public class Role
{
    private Role(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }


    public static Role Create(string name, string description)
        => new Role(name, description);
}