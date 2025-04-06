using System.Security.AccessControl;

namespace NiceTrue.Identity.Domain;

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

// key (UserId)

/*
 *  UserId | RoleId
 *  RoleId | UserId
 * 1      |.  1
 * 2      |.  1
 * 1      |.  2
 * 
 * 
 */
 
 /* 1 1
  * 2 1
  * 
  */