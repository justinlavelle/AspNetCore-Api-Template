using HC.Template.Interface.ServiceModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Template.Interface.Contracts
{
    public interface IExampleService
    {
        ExampleResponse GetApplicationTitle();
        AppSettingsResponse GetApplicationSettings();
    }
}
