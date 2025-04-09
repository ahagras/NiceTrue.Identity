using NiceTrue.Identity.Domain.Enums;

namespace NiceTrue.Identity.Domain.Entities;

public class User
{
    private User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        Status = UserStatus.Pending;
        CreatAt = DateTimeOffset.UtcNow;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserStatus Status { get; private set; }
    public IReadOnlyCollection<UserRole> UserRoles => _userRoles;

    private readonly List<UserRole> _userRoles = [];

    public DateTimeOffset CreatAt { get; private set; } 

    public static User Create(string name, string email, string password)
        => new User(name, email, password);

    public User AssignRole(int userId, int roleId)
    {
        _userRoles.Add(UserRole.Create(userId, roleId));
        return this;
    }
}
