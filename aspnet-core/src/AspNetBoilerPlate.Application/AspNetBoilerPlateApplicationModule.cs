using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetBoilerPlate.Authorization;

namespace AspNetBoilerPlate
{
    [DependsOn(
        typeof(AspNetBoilerPlateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AspNetBoilerPlateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AspNetBoilerPlateAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AspNetBoilerPlateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
