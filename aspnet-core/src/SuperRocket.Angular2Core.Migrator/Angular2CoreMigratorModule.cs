using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using SuperRocket.Angular2Core.Configuration;
using SuperRocket.Angular2Core.EntityFramework;

namespace SuperRocket.Angular2Core.Migrator
{
    [DependsOn(typeof(Angular2CoreEntityFrameworkModule))]
    public class Angular2CoreMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Angular2CoreMigratorModule()
        {
            _appConfiguration = AppConfigurations.Get(
                typeof(Angular2CoreMigratorModule).Assembly.GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Database.SetInitializer<Angular2CoreDbContext>(null);

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                Angular2CoreConsts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}