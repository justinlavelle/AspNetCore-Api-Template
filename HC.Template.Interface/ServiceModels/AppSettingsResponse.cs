using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.Interface.ServiceModels
{
    public class AppSettingsResponse
    {
        public AppSettingsVals AppSettingVals { get; set; }
    }

    public class AppSettingsVals
    {
        public string ApplicationTitle { get; set; }
        public string StringSetting { get; set; }
        public int IntSetting { get; set; }
        public Dictionary<string, InnerClassVals> Dict { get; set; } // Dictionaries must have string keys
        public List<string> ListOfValues { get; set; }
        public string EnumSwitchVal { get; set; }

    }

    public class InnerClassVals
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;
    }

    public enum EnumSwitch
    {
        On = 0,
        Off = 1
    }

}
