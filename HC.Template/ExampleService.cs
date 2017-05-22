using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using HC.Template.Interface.ServiceModels;
using System.Threading.Tasks;
using AutoMapper;

namespace HC.Template.Service
{
    public class ExampleService : IExampleService
    {
        AppSettings _appSettings;
        IMapper _mapper;

        public ExampleService(AppSettings appSettings, IMapper mapper)
        {
            _appSettings = appSettings;
            _mapper = mapper;
        }

        public async Task<ExampleResponse> GetExampleString()
        {
            var response = _appSettings; //_configService.GetAppSettings();
            _appSettings.ApplicationTitle = "Hello Kitty";

            var result = _mapper.Map<AppSettings, ExampleResponse>(response); // Mapping Domain to ServiceModel
            return result;
        }

    }
}
