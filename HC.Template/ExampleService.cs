using HC.Template.Interface.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template
{
    public class ExampleService : IExampleService
    {
        IConfigService _configService;
        public ExampleService(IConfigService configService)
        {
            _configService = configService;
        }
        public string GetExampleString()
        {
            var response = _configService.GetAppSettings();
            return response.ApplicationTitle;
        }
    }
}
