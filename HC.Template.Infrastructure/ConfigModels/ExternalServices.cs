using System;
using System.Collections.Generic;
using System.Text;

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
