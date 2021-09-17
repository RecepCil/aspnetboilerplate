using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AspNetBoilerPlate.Localization
{
    public static class AspNetBoilerPlateLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AspNetBoilerPlateConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AspNetBoilerPlateLocalizationConfigurer).GetAssembly(),
                        "AspNetBoilerPlate.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
