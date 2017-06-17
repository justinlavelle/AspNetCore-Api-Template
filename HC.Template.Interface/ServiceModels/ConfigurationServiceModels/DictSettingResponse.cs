using System.Collections.Generic;

namespace HC.Template.Interface.ServiceModels.ConfigurationServiceModels
{
    public class DictSettingResponse
    {
        public Dictionary<string, InnerClass> DictionaryValues { get; set; } // Dictionaries must have string keys
    }

    public class InnerClass
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;
    }

}
