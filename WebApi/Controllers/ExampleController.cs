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
        private ITestDBService _testService;

        public ExampleController(IExampleService exampleService, ITestDBService testService)
        {
            _exampleService = exampleService;
            _testService = testService;
        }

        [HttpGet]
        [Route("GetApplicationTitle")]
        public async Task<ExampleResponse> GetAppTitleFromConfig()
        { 
            var response = _exampleService.GetApplicationTitle();
            return response;
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