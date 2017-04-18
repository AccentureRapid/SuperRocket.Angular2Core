using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SuperRocket.Angular2Core.MultiTenancy.Dto;

namespace SuperRocket.Angular2Core.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
