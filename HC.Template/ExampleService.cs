using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.Service
{
    public class ExampleService : IExampleService
    {
        IConfigService _configService;
        protected AppSettings _appSettings { get; }

        public ExampleService(IConfigService configService, AppSettings appSettings)
        {
            _configService = configService;
            _appSettings = appSettings;
        }
        public string GetExampleString()
        {
            var response = _appSettings.ApplicationTitle; //_configService.GetAppSettings();
            _appSettings.ApplicationTitle = "Hello Kitty";

            return response;
        }
    }
}
