using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LibHub.Configuration.Dto;

namespace LibHub.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LibHubAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
