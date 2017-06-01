using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.InternalServices.ConfigurationService.Contracts
{
    public interface IConfigService
    {
        AppSettingsResponse GetAppSettings();
        AppTitleResponse GetApplicationTitle();
        StringSettingResponse GetStringSetting();
        IntSettingResponse GetIntSetting();
        EnumSettingResponse GetEnumSetting();
        ListSettingResponse GetListSetting();
        DictSettingResponse GetDictionarySetting();
        
        ConfigSettingsResponse GetConfigSettings();
    }
}
