namespace NiceTrue.Identity.Domain;

public class Permission
{
    private Permission(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }


    public static Permission Create(string name, string description)
        => new Permission(name, description);
}