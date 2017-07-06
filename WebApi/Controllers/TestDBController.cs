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
        public TestObj1Response GetDataFromDynamicSql()
        {
            var response = _testService.GetDynamicSqlData();
            return response;
        }

        [HttpPost]
        [Route("GetDataFromStoredProcedure")]
        public TestObj2Response GetDataFromStoredProcedure(TestObj2Request request)
        {
            var response = _testService.GetStoredProcData(request);
            return response;
        }

    }
}