using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;

namespace HC.Template.Service.InternalServices.ConfigurationService.Contracts
{
    public interface IConfigService
    {
        AppTitleResponse GetApplicationTitle();
        StringSettingResponse GetStringSetting();
        IntSettingResponse GetIntSetting();
        EnumSettingResponse GetEnumSetting();
        ListSettingResponse GetListSetting();
        DictSettingResponse GetDictionarySetting();

        AppSettingsResponse GetAppSettings();
        ConfigSettingsResponse GetConfigSettings();
        ServiceEndpointsResponse GetServiceEndpoints();
    }
}
