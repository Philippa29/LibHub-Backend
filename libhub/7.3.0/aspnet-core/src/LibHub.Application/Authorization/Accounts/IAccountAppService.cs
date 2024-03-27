using System.Threading.Tasks;
using Abp.Application.Services;
using LibHub.Authorization.Accounts.Dto;

namespace LibHub.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
