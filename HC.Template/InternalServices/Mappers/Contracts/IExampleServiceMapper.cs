using HC.Template.Interface.ServiceModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;

namespace HC.Template.InternalServices.Mappers.Contracts
{
    public interface IExampleServiceMapper
    {
        ExampleResponse MapAppSettingsToExample(AppSettingsResponse appSettings);
    }
}
