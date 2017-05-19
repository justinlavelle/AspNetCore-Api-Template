using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Example")]
    public class ExampleController : Controller
    {
        private IExampleService _exampleService;
        private ITestService _testService;

        public ExampleController(IExampleService exampleService, ITestService testService)
        {
            _exampleService = exampleService;
            _testService = testService;
        }

        [HttpPost]
        [Route("CallConfig")]
        public async Task<string> GetAppSettingsFromConfig()
        { 
            var response = _exampleService.GetExampleString();
            return response;
        }

        [HttpPost]
        [Route("CallDB")]
        public async Task<TestResponse> GetTestRecord()
        {
            var response = await _testService.GetTestRecordFromDB();
            return response;
        }
        

    }
}