using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.ServiceModels;
using HC.Template.InternalServices.Configuration.Contracts;
using HC.Template.InternalServices.Mappers.Contracts;
using Microsoft.Extensions.Configuration;

namespace HC.Template.InternalServices.Configuration
{
    public class ConfigService : IConfigService
    {
        private IConfiguration _config;
        private IConfigServiceMapper _mapper;
        protected AppSettings _appSettings { get; }
        protected ConfigSettings _configSettings { get; }

        public ConfigService(IConfiguration config, AppSettings appSettings, ConfigSettings configSettings, IConfigServiceMapper mapper)
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

        public ConfigSettingsResponse GetConfigSettings()
        {
            var response = _configSettings;//_config.GetSection("ConfigSettings") as ConfigSettings;
            var result = _mapper.MapConfigSettings(response);
            return result;
        }
        

    }
}
