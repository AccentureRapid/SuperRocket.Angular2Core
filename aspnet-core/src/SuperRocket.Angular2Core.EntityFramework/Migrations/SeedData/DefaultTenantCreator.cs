using System.Linq;
using SuperRocket.Angular2Core.EntityFramework;
using SuperRocket.Angular2Core.MultiTenancy;

namespace SuperRocket.Angular2Core.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly Angular2CoreDbContext _context;

        public DefaultTenantCreator(Angular2CoreDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
