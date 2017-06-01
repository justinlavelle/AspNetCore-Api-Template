using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.ServiceModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.InternalServices.Mappers.Contracts
{
    public interface IConfigServiceMapper
    {
        AppSettingsResponse MapAppSettings(AppSettings appSettings);
        AppTitleResponse MapApplicationTitle(AppSettings appSettings);
        StringSettingResponse MapStringSetting(AppSettings appSettings);
        IntSettingResponse MapIntSetting(AppSettings appSettings);
        EnumSettingResponse MapEnumSetting(AppSettings appSettings);
        ListSettingResponse MapListSetting(AppSettings appSettings);
        DictSettingResponse MapDictionarySetting(AppSettings appSettings);


        ConfigSettingsResponse MapConfigSettings(ConfigSettings configSettings);
    }
}
