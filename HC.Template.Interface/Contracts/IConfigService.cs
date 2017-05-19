using HC.Template.Infrastructure.ConfigModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.Interface.Contracts
{
    public interface IConfigService
    {
        AppSettings GetAppSettings();
    }
}
