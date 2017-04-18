using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace SuperRocket.Angular2Core.EntityFramework
{
    [DependsOn(
        typeof(Angular2CoreCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class Angular2CoreEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Angular2CoreDbContext>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}