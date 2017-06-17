using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;

namespace HC.Template.InternalServices.Mappers.Contracts
{
    public interface IAppSettingsServiceMapper
    {
        AppSettingsResponse MapAppSettings(AppSettings appSettings);
        ConfigSettingsResponse MapConfigSettings(ConfigSettings configSettings);

        AppTitleResponse MapApplicationTitle(AppSettings appSettings);
        StringSettingResponse MapStringSetting(AppSettings appSettings);
        IntSettingResponse MapIntSetting(AppSettings appSettings);
        EnumSettingResponse MapEnumSetting(AppSettings appSettings);
        ListSettingResponse MapListSetting(AppSettings appSettings);
        DictSettingResponse MapDictionarySetting(AppSettings appSettings);
    }
}
