using System;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.TestBase;
using Abp.Zero.Configuration;
using SuperRocket.Angular2Core.EntityFramework;
using Castle.MicroKernel.Registration;
using NSubstitute;

namespace SuperRocket.Angular2Core.Tests
{
    [DependsOn(
        typeof(Angular2CoreApplicationModule),
        typeof(Angular2CoreEntityFrameworkModule),
        typeof(AbpTestBaseModule)
        )]
    public class Angular2CoreTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<IAbpZeroDbMigrator>();
        }

        private void RegisterFakeService<TService>() where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }
    }
}