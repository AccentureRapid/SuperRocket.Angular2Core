using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNet.Identity;

namespace SuperRocket.Angular2Core.Controllers
{
    public abstract class Angular2CoreControllerBase: AbpController
    {
        protected Angular2CoreControllerBase()
        {
            LocalizationSourceName = Angular2CoreConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}