using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using HC.Template.Interface.ServiceModels;
using System.Threading.Tasks;
using HC.Template.Mappers;

namespace HC.Template.Service
{
    public class ExampleService : IExampleService
    {
        AppSettings _appSettings;
        private ExampleServiceMapper _mapper;

        public ExampleService(AppSettings appSettings, ExampleServiceMapper mapper)
        {
            _appSettings = appSettings;
            _mapper = mapper;
        }

        public async Task<ExampleResponse> GetExampleString()
        {
            var response = _appSettings; //_configService.GetAppSettings();
            //_appSettings.ApplicationTitle = "Hello Kitty";

            var result = _mapper.MapGetExampleString(response); //_mapper.Map<AppSettings, ExampleResponse>(response); // Mapping Domain to ServiceModel
            
            return result;
        }

    }
}
