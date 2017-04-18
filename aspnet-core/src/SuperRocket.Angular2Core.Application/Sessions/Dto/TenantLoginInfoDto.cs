using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SuperRocket.Angular2Core.MultiTenancy;

namespace SuperRocket.Angular2Core.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}