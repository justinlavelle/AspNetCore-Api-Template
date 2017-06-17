using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels.TestServiceModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HC.Template.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/TestDB")]
    public class TestDBController : Controller
    {
        private ITestDBService _testService;

        public TestDBController(ITestDBService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        [Route("GetDataFromDynamicSql")]
        public async Task<TestObj1Response> GetDataFromDynamicSql()
        {
            var response = await _testService.GetDynamicSqlData();
            return response;
        }

        [HttpPost]
        [Route("GetDataFromStoredProcedure")]
        public async Task<TestObj2Response> GetDataFromStoredProcedure(TestObj2Request request)
        {
            var response = await _testService.GetStoredProcData(request);
            return response;
        }

    }
}