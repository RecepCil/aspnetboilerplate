using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetBoilerPlate.Configuration;
using AspNetBoilerPlate.EntityFrameworkCore;
using AspNetBoilerPlate.Migrator.DependencyInjection;

namespace AspNetBoilerPlate.Migrator
{
    [DependsOn(typeof(AspNetBoilerPlateEntityFrameworkModule))]
    public class AspNetBoilerPlateMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AspNetBoilerPlateMigratorModule(AspNetBoilerPlateEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(AspNetBoilerPlateMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AspNetBoilerPlateConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetBoilerPlateMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
