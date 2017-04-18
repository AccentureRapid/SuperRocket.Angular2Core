using System.Reflection;
using Abp.Modules;
using SuperRocket.Angular2Core.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace SuperRocket.Angular2Core.Web.Host.Startup
{
    [DependsOn(
       typeof(Angular2CoreWebCoreModule))]
    public class Angular2CoreWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Angular2CoreWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
