using System.Collections.Generic;

namespace SuperRocket.Angular2Core.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
