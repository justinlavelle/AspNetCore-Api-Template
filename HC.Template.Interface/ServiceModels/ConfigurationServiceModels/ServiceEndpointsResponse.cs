using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.Interface.ServiceModels.ConfigurationServiceModels
{
    public class ServiceEndpointsResponse
    {
        public Dictionary<string, ServiceEndpointAttributes> ServiceEndPoints { get; set; } // Dictionaries must have string keys
    }

    public class ServiceEndpointAttributes
    {
        public string Url { get; set; }
    }

}
