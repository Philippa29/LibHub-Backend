using Abp.Authorization;
using LibHub.Authorization.Roles;
using LibHub.Authorization.Users;

namespace LibHub.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
