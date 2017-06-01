using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.Interface.ServiceModels.ConfigurationServiceModels
{
    public class ConfigSettingsResponse
    {
        public string StrSetting { get; set; }
        public int IntSetting { get; set; }
        public bool BoolSetting { get; set; }
    }
}
