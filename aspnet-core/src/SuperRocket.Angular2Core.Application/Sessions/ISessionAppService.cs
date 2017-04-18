using System.Threading.Tasks;
using Abp.Application.Services;
using SuperRocket.Angular2Core.Sessions.Dto;

namespace SuperRocket.Angular2Core.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
