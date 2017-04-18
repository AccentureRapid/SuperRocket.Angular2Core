using System.Threading.Tasks;
using Abp.Zero.AspNetCore;

namespace SuperRocket.Angular2Core.Authentication.External
{
    public interface IExternalAuthManager
    {
        Task<bool> IsValidUser(string provider, string providerKey, string providerAccessCode);

        Task<ExternalLoginUserInfo> GetUserInfo(string provider, string accessCode);
    }
}
