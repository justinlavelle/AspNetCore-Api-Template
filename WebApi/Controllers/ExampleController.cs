using System.Threading.Tasks;
using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Example")]
    public class ExampleController : Controller
    {
        private IExampleService _exampleService;

        public ExampleController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [HttpGet]
        [Route("GetApplicationSettings")]
        public async Task<AppSettingsResponse> GetAppSettingsFromConfig()
        {
            var response = _exampleService.GetApplicationSettings();
            return response;
        }

    }
}