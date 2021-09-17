using System.Collections.Generic;

namespace AspNetBoilerPlate.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
