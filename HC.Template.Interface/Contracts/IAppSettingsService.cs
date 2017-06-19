using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;

namespace HC.Template.Interface.Contracts
{
    public interface IAppSettingsService // This must be removed eventually as you do not want to expose this to the outside world
    {
        AppTitleResponse GetApplicationTitle();
        StringSettingResponse GetStringSetting();
        IntSettingResponse GetIntSetting();
        EnumSettingResponse GetEnumSetting();
        ListSettingResponse GetListSetting();
        DictSettingResponse GetDictionarySetting();

        AppSettingsResponse GetApplicationSettings();
        ConfigSettingsResponse GetConfigSettings();
        ServiceEndpointsResponse GetServiceEndpoints();
    }
}
