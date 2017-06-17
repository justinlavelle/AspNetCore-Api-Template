using HC.Template.Infrastructure.Logging;
using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using HC.Template.InternalServices.ConfigurationService.Contracts;
using HC.Template.InternalServices.Mappers.Contracts;

namespace HC.Template.Service
{
    public class AppSettingsService : IAppSettingsService
    {
        //AppSettings _appSettings;
        private IConfigService _config;
        private IAppSettingsServiceMapper _mapper;
        private ILoggerService _loggerService;

        public AppSettingsService(IConfigService config, IAppSettingsServiceMapper mapper, ILoggerService loggerService)
        {
            _config = config;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        public AppTitleResponse GetApplicationTitle()
        {
            var response = _config.GetApplicationTitle();
            return response;
        }

        public StringSettingResponse GetStringSetting()
        {
            var response = _config.GetStringSetting();
            return response;
        }

        public IntSettingResponse GetIntSetting()
        {
            var response = _config.GetIntSetting();
            return response;
        }

        public EnumSettingResponse GetEnumSetting()
        {
            var response = _config.GetEnumSetting();
            return response;
        }

        public ListSettingResponse GetListSetting()
        {
            var response = _config.GetListSetting();
            return response;
        }

        public DictSettingResponse GetDictionarySetting()
        {
            var response = _config.GetDictionarySetting();
            return response;
        }


        public AppSettingsResponse GetApplicationSettings()
        {
            // _loggerService.LogDebug("This is a debug message");
            // _loggerService.LogInformation("This is an information message");

            var response = _config.GetAppSettings();
            return response;
        }

        public ConfigSettingsResponse GetConfigSettings()
        {
            // _loggerService.LogDebug("This is a debug message");
            // _loggerService.LogInformation("This is an information message");

            var response = _config.GetConfigSettings();
            return response;
        }
    }
}
