using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using HC.Template.InternalServices.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HC.Template.InternalServices.Mappers
{
    public class AppSettingsServiceMapper : IAppSettingsServiceMapper
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
            var result = new AppSettingsResponse()
            {
                AppSettingVals = new AppSettingsVals()
                {
                    ApplicationTitle = appSettings.ApplicationTitle,
                    Dict = new Dictionary<string, InnerClassVals>(),
                    EnumSwitchVal = (EnumSwitch) Convert.ToInt32(appSettings.AnEnumSwitch),
                    IntSetting = appSettings.IntSetting,
                    StringSetting = appSettings.StringSetting
                }
            };

            // Mapping a list
            var stringList = new List<string>();
            foreach(var stringVal in appSettings.ListOfValues)
            {
                stringList.Add(stringVal);
            }

            result.AppSettingVals.ListOfValues = stringList.AsEnumerable();

            // Mapping a dictionary - which is a generic collection
            foreach (var dictEntry in appSettings.DictSetting)
            {
                var innerClassVal = new InnerClassVals()
                {
                    IsEnabled = dictEntry.Value.IsEnabled,
                    Name = dictEntry.Value.Name
                };

                result.AppSettingVals.Dict.Add(dictEntry.Key, innerClassVal);
            }

            return result;
        }

        public ConfigSettingsResponse MapConfigSettings(ConfigSettings configSettings)
        {
            var result = new ConfigSettingsResponse()
            {
                BoolSetting = configSettings.SettingBool,
                IntSetting = configSettings.SettingInt,
                StrSetting = configSettings.SettingStr
            };

            return result;
        }

        public DictSettingResponse MapDictionarySetting(AppSettings appSettings)
        {
            var result = new DictSettingResponse()
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

                result.DictionaryValues.Add(dictEntry.Key, innerClassVal);
            }

            return result;
        }

        public EnumSettingResponse MapEnumSetting(AppSettings appSettings)
        {
            var result = new EnumSettingResponse()
            {
                InternalEnum = (InternalEnum)Convert.ToInt32(appSettings.AnEnumSwitch),
            };

            return result;
        }

        public IntSettingResponse MapIntSetting(AppSettings appSettings)
        {
            var result = new IntSettingResponse()
            {
                IntValue = appSettings.IntSetting
            };

            return result;
        }

        public ListSettingResponse MapListSetting(AppSettings appSettings)
        {
            // Mapping a list
            var stringList = new List<string>();
            foreach (var stringVal in appSettings.ListOfValues)
            {
                stringList.Add(stringVal);
            }

            var result = new ListSettingResponse()
            {
                ListOfStrings = stringList.AsEnumerable()
            };

            return result;
        }

        public StringSettingResponse MapStringSetting(AppSettings appSettings)
        {
            var result = new StringSettingResponse()
            {
                 StringValue = appSettings.StringSetting
            };

            return result;
        }
    }
}
