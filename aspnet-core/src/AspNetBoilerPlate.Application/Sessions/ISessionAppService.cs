using System.Threading.Tasks;
using Abp.Application.Services;
using AspNetBoilerPlate.Sessions.Dto;

namespace AspNetBoilerPlate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
