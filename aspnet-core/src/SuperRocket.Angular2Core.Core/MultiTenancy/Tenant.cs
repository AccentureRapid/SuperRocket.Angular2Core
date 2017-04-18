using Abp.MultiTenancy;
using SuperRocket.Angular2Core.Authorization.Users;

namespace SuperRocket.Angular2Core.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}