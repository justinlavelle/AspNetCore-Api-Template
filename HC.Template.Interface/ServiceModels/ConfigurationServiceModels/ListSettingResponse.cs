using System.Collections.Generic;

namespace HC.Template.Interface.ServiceModels.ConfigurationServiceModels
{
    public class ListSettingResponse
    {
        public IEnumerable<string> ListOfStrings { get; set; }
    }
}
