using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using HC.Template.InternalServices.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HC.Template.InternalServices.Mappers
{
    public class ConfigServiceMapper : IConfigServiceMapper
    {
        public AppTitleResponse MapApplicationTitle(AppSettings appSettings)
        {
            var response = new AppTitleResponse()
            {
                AppTitleValue = appSettings.ApplicationTitle
            };

            return response;
        }

        public AppSettingsResponse MapAppSettings(AppSettings appSettings)
        {
            var response = new AppSettingsResponse()
            {
                AppSettingVals = new AppSettingsVals()
                {
                    ApplicationTitle = appSettings.ApplicationTitle,
                    Dict = new Dictionary<string, InnerClassVals>(),
                    ListOfValues = new List<string>(),
                    EnumSwitchVal = (EnumSwitch) Convert.ToInt32(appSettings.AnEnumSwitch),
                    IntSetting = appSettings.IntSetting,
                    StringSetting = appSettings.StringSetting
                }
            };

            // Mapping a list
            foreach(var listVal in appSettings.ListOfValues)
            {
                
                response.AppSettingVals.ListOfValues.ToList().Add(listVal);
            }

            // Mapping a dictionary - which is a generic collection
            foreach(var dictEntry in appSettings.DictSetting)
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

        public DictSettingResponse MapDictionarySetting(AppSettings appSettings)
        {
            var response = new DictSettingResponse()
            {
                DictionaryValues = new Dictionary<string, InnerClass>()
            };

            foreach (var dictEntry in appSettings.DictSetting)
            {
                var innerClassVal = new InnerClass()
                {
                    IsEnabled = dictEntry.Value.IsEnabled,
                    Name = dictEntry.Value.Name
                };

                response.DictionaryValues.Add(dictEntry.Key, innerClassVal);
            }

            return response;
        }

        public EnumSettingResponse MapEnumSetting(AppSettings appSettings)
        {
            var response = new EnumSettingResponse()
            {
                InternalEnum = (InternalEnum)Convert.ToInt32(appSettings.AnEnumSwitch),
            };

            return response;
        }

        public IntSettingResponse MapIntSetting(AppSettings appSettings)
        {
            var response = new IntSettingResponse()
            {
                IntValue = appSettings.IntSetting
            };

            return response;
        }

        public ListSettingResponse MapListSetting(AppSettings appSettings)
        {
            var response = new ListSettingResponse()
            {
                 ListOfStrings = new List<string>()
            };

            foreach (var listVal in appSettings.ListOfValues)
            {
                response.ListOfStrings.ToList().Add(listVal);
            }

            return response;
        }

        public StringSettingResponse MapStringSetting(AppSettings appSettings)
        {
            var response = new StringSettingResponse()
            {
                 StringValue = appSettings.StringSetting
            };

            return response;
        }
    }
}
