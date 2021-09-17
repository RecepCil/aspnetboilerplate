using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AspNetBoilerPlate.Configuration.Dto;

namespace AspNetBoilerPlate.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AspNetBoilerPlateAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
