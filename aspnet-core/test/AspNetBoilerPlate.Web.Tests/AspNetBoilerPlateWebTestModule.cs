using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetBoilerPlate.EntityFrameworkCore;
using AspNetBoilerPlate.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AspNetBoilerPlate.Web.Tests
{
    [DependsOn(
        typeof(AspNetBoilerPlateWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AspNetBoilerPlateWebTestModule : AbpModule
    {
        public AspNetBoilerPlateWebTestModule(AspNetBoilerPlateEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetBoilerPlateWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AspNetBoilerPlateWebMvcModule).Assembly);
        }
    }
}