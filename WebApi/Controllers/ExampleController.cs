using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels;
using HC.Template.Interface.ServiceModels.ConfigurationServiceModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Example")]
    public class ExampleController : Controller
    {
        private IExampleService _exampleService;
        private ITestDBService _testService;
     //   private ILogger _logger;

        public ExampleController(IExampleService exampleService, ITestDBService testService)
        {
            _exampleService = exampleService;
            _testService = testService;
//            _logger = logger;

        }

        [HttpGet]
        [Route("GetApplicationSettings")]
        public async Task<AppSettingsResponse> GetAppSettingsFromConfig()
        {
            var response = _exampleService.GetApplicationSettings();
            return response;
        }

        [HttpPost]
        [Route("GetDBTestRecords")]
        public async Task<TestObjResponse> GetTestRecord()
        {
            var response = await _testService.GetTestRecordFromDB();
            return response;
        }
        

    }
}