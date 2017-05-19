using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template
{
    public class ConfigService : IConfigService
    {
        private IConfiguration _config { get; }

        public ConfigService(IConfiguration config)
        {
            _config = config;
        }

        public AppSettings GetAppSettings()
        {
            return _config.GetSection("AppSettings") as AppSettings;
        }
    }
}
