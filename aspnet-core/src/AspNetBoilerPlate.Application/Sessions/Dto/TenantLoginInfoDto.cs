using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AspNetBoilerPlate.MultiTenancy;

namespace AspNetBoilerPlate.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
