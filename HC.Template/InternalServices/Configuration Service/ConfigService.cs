using System;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using HC.Template.InternalServices.ConfigurationService.Contracts;
using HC.Template.InternalServices.Mappers.Contracts;
using Microsoft.Extensions.Configuration;

namespace HC.Template.InternalServices.ConfigurationService
{
    public class ConfigService : IConfigService
    {
        private IConfiguration _config;
        private IConfigServiceMapper _mapper;
        protected AppSettings _appSettings { get; }
        protected ConfigSettings _configSettings { get; }
        protected ConnectionStrings _connStrings { get; }

        public ConfigService(IConfiguration config, AppSettings appSettings, ConfigSettings configSettings, IConfigServiceMapper mapper, ConnectionStrings _connStrings)
        {
            _config = config;
            _appSettings = appSettings;
            _configSettings = configSettings;
            _mapper = mapper;
        }

        public AppSettingsResponse GetAppSettings()
        {
            var response = _appSettings;//_config.GetSection("AppSettings") as AppSettings;
            var result = _mapper.MapAppSettings(response);
            return result;
        }

        public AppTitleResponse GetApplicationTitle()
        {
            var response = _appSettings;
            var result = _mapper.MapApplicationTitle(response);
            return result;
        }

        public StringSettingResponse GetStringSetting()
        {
            var response = _appSettings;
            var result = _mapper.MapStringSetting(response);
            return result;
        }

        public IntSettingResponse GetIntSetting()
        {
            var response = _appSettings;
            var result = _mapper.MapIntSetting(response);
            return result;
        }

        public EnumSettingResponse GetEnumSetting()
        {
            var response = _appSettings;
            var result = _mapper.MapEnumSetting(response);
            return result;
        }

        public ListSettingResponse GetListSetting()
        {
            var response = _appSettings;
            var result = _mapper.MapListSetting(response);
            return result;
        }

        public DictSettingResponse GetDictionarySetting()
        {
            var response = _appSettings;
            var result = _mapper.MapDictionarySetting(response);
            return result;
        }

        public ConfigSettingsResponse GetConfigSettings()
        {
            var response = _configSettings;//_config.GetSection("ConfigSettings") as ConfigSettings;
            var result = _mapper.MapConfigSettings(response);
            return result;
        }

    }
}
