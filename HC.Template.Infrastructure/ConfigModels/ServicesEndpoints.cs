using System.Collections.Generic;

namespace HC.Template.Infrastructure.ConfigModels
{
    public class ServicesEndpoints
    {
        public Dictionary<string, ServiceAttributes> Services { get; set; } // Dictionaries must have string keys
    }

    public class ServiceAttributes
    {
        public string Url { get; set; }
    }
}
