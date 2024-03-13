using System.Threading.Tasks;
using LibHub.Configuration.Dto;

namespace LibHub.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
