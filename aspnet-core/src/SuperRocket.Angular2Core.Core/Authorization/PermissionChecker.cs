using Abp.Authorization;
using SuperRocket.Angular2Core.Authorization.Roles;
using SuperRocket.Angular2Core.Authorization.Users;
using SuperRocket.Angular2Core.MultiTenancy;

namespace SuperRocket.Angular2Core.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
