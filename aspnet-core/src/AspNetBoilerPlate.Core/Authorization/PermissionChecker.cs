using Abp.Authorization;
using AspNetBoilerPlate.Authorization.Roles;
using AspNetBoilerPlate.Authorization.Users;

namespace AspNetBoilerPlate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
