using Abp.Application.Services;
using AspNetBoilerPlate.MultiTenancy.Dto;

namespace AspNetBoilerPlate.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

