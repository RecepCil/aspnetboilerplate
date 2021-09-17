using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AspNetBoilerPlate.EntityFrameworkCore.Seed;

namespace AspNetBoilerPlate.EntityFrameworkCore
{
    [DependsOn(
        typeof(AspNetBoilerPlateCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class AspNetBoilerPlateEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<AspNetBoilerPlateDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        AspNetBoilerPlateDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        AspNetBoilerPlateDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetBoilerPlateEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
