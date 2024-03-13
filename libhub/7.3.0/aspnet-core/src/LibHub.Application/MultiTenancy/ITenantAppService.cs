using Abp.Application.Services;
using LibHub.MultiTenancy.Dto;

namespace LibHub.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

