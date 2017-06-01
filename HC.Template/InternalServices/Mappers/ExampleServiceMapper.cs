using HC.Template.Interface.ServiceModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using HC.Template.InternalServices.Mappers.Contracts;

namespace HC.Template.InternalServices.Mappers
{
    public class ExampleServiceMapper : IExampleServiceMapper
    {
        public ExampleResponse MapAppSettingsToExample(AppSettingsResponse appSettings)
        {
            var response = new ExampleResponse()
            {
                ApplicationTitle = appSettings.AppSettingVals.ApplicationTitle
            };

            return response;
        }
    }
}
