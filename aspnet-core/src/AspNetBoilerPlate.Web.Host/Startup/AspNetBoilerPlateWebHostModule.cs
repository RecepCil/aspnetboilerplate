using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetBoilerPlate.Configuration;

namespace AspNetBoilerPlate.Web.Host.Startup
{
    [DependsOn(
       typeof(AspNetBoilerPlateWebCoreModule))]
    public class AspNetBoilerPlateWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AspNetBoilerPlateWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetBoilerPlateWebHostModule).GetAssembly());
        }
    }
}
