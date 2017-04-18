using System.Reflection;
using Abp.Modules;
using Abp.Timing;
using Abp.Zero;
using SuperRocket.Angular2Core.Localization;
using Abp.Zero.Configuration;
using SuperRocket.Angular2Core.MultiTenancy;
using SuperRocket.Angular2Core.Authorization.Roles;
using SuperRocket.Angular2Core.Authorization.Users;
using SuperRocket.Angular2Core.Timing;

namespace SuperRocket.Angular2Core
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class Angular2CoreCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            Angular2CoreLocalizationConfigurer.Configure(Configuration.Localization);

            //Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = Angular2CoreConsts.MultiTenancyEnabled;

            //Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}