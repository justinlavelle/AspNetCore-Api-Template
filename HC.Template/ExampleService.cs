using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using HC.Template.InternalServices.ConfigurationService.Contracts;
using HC.Template.InternalServices.Mappers.Contracts;

namespace HC.Template.Service
{
    public class ExampleService : IExampleService
    {
        //AppSettings _appSettings;
        private IConfigService _config;
        private IExampleServiceMapper _mapper;

        public ExampleService(IConfigService config, IExampleServiceMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public ExampleResponse GetApplicationTitle()
        {
            var response = _config.GetAppSettings();
            var result = _mapper.MapAppSettingsToExample(response);
            
            return result;
        }

        public AppSettingsResponse GetApplicationSettings()
        {
            var response = _config.GetAppSettings();

            return response;
        }

    }
}
