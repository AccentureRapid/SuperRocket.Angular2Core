using Abp.Authorization.Roles;
using SuperRocket.Angular2Core.Authorization.Users;

namespace SuperRocket.Angular2Core.Authorization.Roles
{
    public class Role : AbpRole<User>
    {
        //Can add application specific role properties here

        public Role()
        {

        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }
    }
}