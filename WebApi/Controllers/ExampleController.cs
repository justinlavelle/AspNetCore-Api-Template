using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HC.Template.Interface.Contracts;

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

        [HttpPost]
        [Route("CallConfig")]
        public async Task<string> SaveLeadCallBack()
        { 
            var response = _exampleService.GetExampleString();
            return response;
        }

    }
}