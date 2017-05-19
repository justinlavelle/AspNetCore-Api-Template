using HC.Template.Interface.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using HC.Template.Infrastructure.ConfigModels;

namespace HC.Template.Service
{
    public class ConfigService : IConfigService
    {
        IConfiguration _config;
        protected AppSettings _appSettings { get; }
        public ConfigService(IConfiguration config, AppSettings appSettings)
        {
            _config = config;
            _appSettings = appSettings;
        }

        public AppSettings GetAppSettings()
        {
            var response = _config.GetSection("AppSettings") as AppSettings;
            return response;
        }

        AppSettings IConfigService.GetAppSettings()
        {
            throw new NotImplementedException();
        }
    }
}
