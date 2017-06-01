using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.Infrastructure.ConfigModels
{

    /* 
       When values aren't provided, they get their default values, (e.g. MySettings.Dict["SecondKey].IsEnabled == true). Dictionaries, lists and enums are all bound correctly. 
       PLEASE bear the following in mind when creating these properties from out of the appsettings.json:

        * Properties must have a public Set method...
        * Dictionaries must have string keys
        * Don't expose IDictionary
        * 
    */

    public class AppSettings
    {
        public string ApplicationTitle { get; set; }
        public string StringSetting { get; set; }
        public int IntSetting { get; set; }
        public Dictionary<string, MyClass> DictSetting { get; set; } // Dictionaries must have string keys
        public IEnumerable<string> ListOfValues { get; set; }
        public MyEnum AnEnumSwitch { get; set; }

    }

    public class MyClass
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;
    }

    public enum MyEnum
    {
        Off = 0,
        On = 1
    }

}
