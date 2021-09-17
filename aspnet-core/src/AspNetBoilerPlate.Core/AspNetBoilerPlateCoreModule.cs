using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using AspNetBoilerPlate.Authorization.Roles;
using AspNetBoilerPlate.Authorization.Users;
using AspNetBoilerPlate.Configuration;
using AspNetBoilerPlate.Localization;
using AspNetBoilerPlate.MultiTenancy;
using AspNetBoilerPlate.Timing;

namespace AspNetBoilerPlate
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AspNetBoilerPlateCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AspNetBoilerPlateLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AspNetBoilerPlateConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = AspNetBoilerPlateConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetBoilerPlateCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
