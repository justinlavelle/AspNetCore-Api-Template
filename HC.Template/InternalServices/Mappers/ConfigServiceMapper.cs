using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.ServiceModels;
using HC.Template.InternalServices.Mappers.Contracts;
using System;

namespace HC.Template.InternalServices.Mappers
{
    public class ConfigServiceMapper : IConfigServiceMapper
    {
        public AppSettingsResponse MapAppSettings(AppSettings appSettings)
        {
            var response = new AppSettingsResponse()
            {
                AppSettingVals = new AppSettingsVals()
                {
                    ApplicationTitle = appSettings.ApplicationTitle,
                    Dict = new System.Collections.Generic.Dictionary<string, InnerClassVals>(),
                    EnumSwitchVal = appSettings.AnEnumSwitch
                    IntSetting = appSettings.IntSetting,
                    ListOfValues = appSettings.ListOfValues,
                    StringSetting = appSettings.StringSetting
                }
            };

            // Mapping a dictionary - which is a generic collection
            foreach(var dictEntry in appSettings.Dict)
            {
                var innerClassVal = new InnerClassVals()
                {
                    IsEnabled = dictEntry.Value.IsEnabled,
                    Name = dictEntry.Value.Name
                };

                response.AppSettingVals.Dict.Add(dictEntry.Key, innerClassVal);
            }

            return response;
        }

        public ConfigSettingsResponse MapConfigSettings(ConfigSettings configSettings)
        {
            throw new NotImplementedException();
        }
    }
}
