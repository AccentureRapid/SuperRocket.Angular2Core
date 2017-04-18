using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using SuperRocket.Angular2Core.Authorization.Users;
using SuperRocket.Angular2Core.Editions;

namespace SuperRocket.Angular2Core.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore
            )
        {
        }
    }
}