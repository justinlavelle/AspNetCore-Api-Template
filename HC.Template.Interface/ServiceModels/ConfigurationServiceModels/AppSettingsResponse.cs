using System.Collections.Generic;

namespace HC.Template.Interface.ServiceModels.ConfigurationServiceModels
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
        public IEnumerable<string> ListOfValues { get; set; }
        public EnumSwitch EnumSwitchVal { get; set; }

    }

    public class InnerClassVals
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;
    }

    public enum EnumSwitch
    {
        Off = 0,
        On = 1
    }

}
