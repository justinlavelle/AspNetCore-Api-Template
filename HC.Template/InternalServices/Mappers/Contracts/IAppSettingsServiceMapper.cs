using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;

namespace HC.Template.InternalServices.Mappers.Contracts
{
    public interface IAppSettingsServiceMapper// Make sure to map this in Startup.cs for Dependency Injection (DI)
    {
        AppSettingsResponse MapAppSettings(AppSettings appSettings);
        ConfigSettingsResponse MapConfigSettings(ConfigSettings configSettings);
        ServiceEndpointsResponse MapServiceEndpoints(ServicesEndpoints serviceEndpoints);

        AppTitleResponse MapApplicationTitle(AppSettings appSettings);
        StringSettingResponse MapStringSetting(AppSettings appSettings);
        IntSettingResponse MapIntSetting(AppSettings appSettings);
        EnumSettingResponse MapEnumSetting(AppSettings appSettings);
        ListSettingResponse MapListSetting(AppSettings appSettings);
        DictSettingResponse MapDictionarySetting(AppSettings appSettings);
    }
}
