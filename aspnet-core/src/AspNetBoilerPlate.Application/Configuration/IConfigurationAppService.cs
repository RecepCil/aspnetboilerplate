using System.Threading.Tasks;
using AspNetBoilerPlate.Configuration.Dto;

namespace AspNetBoilerPlate.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
