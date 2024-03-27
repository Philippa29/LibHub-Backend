using System.Threading.Tasks;
using Abp.Application.Services;
using LibHub.Sessions.Dto;

namespace LibHub.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
