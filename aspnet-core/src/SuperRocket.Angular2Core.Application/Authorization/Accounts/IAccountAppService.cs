using System.Threading.Tasks;
using Abp.Application.Services;
using SuperRocket.Angular2Core.Authorization.Accounts.Dto;

namespace SuperRocket.Angular2Core.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
