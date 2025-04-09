namespace NiceTrue.Identity.Domain.Entities;

public class UserRole
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    private UserRole(int userId, int roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    internal static UserRole Create(int userId, int roleId)
        => new UserRole(userId, roleId);
}
