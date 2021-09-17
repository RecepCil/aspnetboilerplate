using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AspNetBoilerPlate.Controllers
{
    public abstract class AspNetBoilerPlateControllerBase: AbpController
    {
        protected AspNetBoilerPlateControllerBase()
        {
            LocalizationSourceName = AspNetBoilerPlateConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
