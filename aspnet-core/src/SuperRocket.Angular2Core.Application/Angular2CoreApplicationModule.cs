using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using SuperRocket.Angular2Core.Authorization;

namespace SuperRocket.Angular2Core
{
    [DependsOn(
        typeof(Angular2CoreCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class Angular2CoreApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<Angular2CoreAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}