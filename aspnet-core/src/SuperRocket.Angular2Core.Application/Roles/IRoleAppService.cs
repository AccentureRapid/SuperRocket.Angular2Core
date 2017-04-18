using System.Threading.Tasks;
using Abp.Application.Services;
using SuperRocket.Angular2Core.Roles.Dto;

namespace SuperRocket.Angular2Core.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
