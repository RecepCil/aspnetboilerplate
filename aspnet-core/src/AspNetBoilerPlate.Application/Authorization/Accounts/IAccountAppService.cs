using System.Threading.Tasks;
using Abp.Application.Services;
using AspNetBoilerPlate.Authorization.Accounts.Dto;

namespace AspNetBoilerPlate.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
