using System.Data.Common;
using System.Data.Entity;
using Abp.Notifications;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using SuperRocket.Angular2Core.Authorization.Roles;
using SuperRocket.Angular2Core.Authorization.Users;
using SuperRocket.Angular2Core.Configuration;
using SuperRocket.Angular2Core.MultiTenancy;
using SuperRocket.Angular2Core.Web;

namespace SuperRocket.Angular2Core.EntityFramework
{
    [DbConfigurationType(typeof(Angular2CoreDbConfiguration))]
    public class Angular2CoreDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        /* Default constructor is needed for EF command line tool. */
        public Angular2CoreDbContext()
            : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                Angular2CoreConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of Angular2CoreDbContext since ABP automatically handles it.
         */
        public Angular2CoreDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public Angular2CoreDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }

        public Angular2CoreDbContext(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {

        }
    }

    public class Angular2CoreDbConfiguration : DbConfiguration
    {
        public Angular2CoreDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
