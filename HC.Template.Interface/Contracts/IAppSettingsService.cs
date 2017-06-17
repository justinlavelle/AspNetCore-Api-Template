using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;

namespace HC.Template.Interface.Contracts
{
    public interface IAppSettingsService
    {
        AppTitleResponse GetApplicationTitle();
        StringSettingResponse GetStringSetting();
        IntSettingResponse GetIntSetting();
        EnumSettingResponse GetEnumSetting();
        ListSettingResponse GetListSetting();
        DictSettingResponse GetDictionarySetting();

        AppSettingsResponse GetApplicationSettings();
        ConfigSettingsResponse GetConfigSettings();
    }
}
