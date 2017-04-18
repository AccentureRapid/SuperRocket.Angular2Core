using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using SuperRocket.Angular2Core.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace SuperRocket.Angular2Core.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Angular2Core.EntityFramework.Angular2CoreDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Angular2Core";
        }

        protected override void Seed(Angular2Core.EntityFramework.Angular2CoreDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
