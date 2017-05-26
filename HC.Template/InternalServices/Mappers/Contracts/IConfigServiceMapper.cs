using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Interface.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.InternalServices.Mappers.Contracts
{
    public interface IConfigServiceMapper
    {
        AppSettingsResponse MapAppSettings(AppSettings appSettings);
        ConfigSettingsResponse MapConfigSettings(ConfigSettings configSettings);
    }
}
