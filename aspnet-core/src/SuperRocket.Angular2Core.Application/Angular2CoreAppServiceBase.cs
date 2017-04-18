using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using SuperRocket.Angular2Core.MultiTenancy;
using Microsoft.AspNet.Identity;
using Abp.Runtime.Session;
using Abp.IdentityFramework;
using SuperRocket.Angular2Core.Authorization.Users;

namespace SuperRocket.Angular2Core
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class Angular2CoreAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected Angular2CoreAppServiceBase()
        {
            LocalizationSourceName = Angular2CoreConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}