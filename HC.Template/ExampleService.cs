using HC.Template.Infrastructure;
using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using HC.Template.InternalServices.ConfigurationService.Contracts;
using HC.Template.InternalServices.Mappers.Contracts;
using System;

namespace HC.Template.Service
{
    public class ExampleService : IExampleService
    {
        //AppSettings _appSettings;
        private IConfigService _config;
        private IExampleServiceMapper _mapper;
        private ILoggerService _loggerService;

        public ExampleService(IConfigService config, IExampleServiceMapper mapper, ILoggerService loggerService)
        {
            _config = config;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        public ExampleResponse GetApplicationTitle()
        {
            var response = _config.GetAppSettings();
            var result = _mapper.MapAppSettingsToExample(response);            
            
            return result;
        }

        public AppSettingsResponse GetApplicationSettings()
        {
            // _loggerService.LogDebug("This is a debug message");
            // _loggerService.LogInformation("This is an information message");

            var response = _config.GetAppSettings();            

            return response;
        }

    }
}
