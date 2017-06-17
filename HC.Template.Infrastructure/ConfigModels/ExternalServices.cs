using System.Collections.Generic;

namespace HC.Template.Infrastructure.ConfigModels
{
    public class ExternalServices
    {
        public Dictionary<string, InnerClass> Services { get; set; } // Dictionaries must have string keys

        public class InnerClass
        {
            public string Url { get; set; }
        }
    }
}
