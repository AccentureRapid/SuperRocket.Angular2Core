using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SuperRocket.Angular2Core.Users.Dto;

namespace SuperRocket.Angular2Core.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        Task<ListResultDto<UserListDto>> GetUsers();

        Task CreateUser(CreateUserInput input);
    }
}