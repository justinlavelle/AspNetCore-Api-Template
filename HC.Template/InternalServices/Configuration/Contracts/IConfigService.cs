using HC.Template.Interface.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.InternalServices.Configuration.Contracts
{
    public interface IConfigService
    {
        AppSettingsResponse GetAppSettings();
        ConfigSettingsResponse GetConfigSettings();
    }
}
