using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LibHub.Controllers
{
    public abstract class LibHubControllerBase: AbpController
    {
        protected LibHubControllerBase()
        {
            LocalizationSourceName = LibHubConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
