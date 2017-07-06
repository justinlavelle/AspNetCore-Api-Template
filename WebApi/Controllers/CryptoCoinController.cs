using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels.CryptoCurrency;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HC.Template.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CryptoCoin")]
    public class CryptoCoinController : Controller
    {
        private ICryptoCoinService _crytpoCoinService;

        public CryptoCoinController(ICryptoCoinService crytpoCoinService)
        {
            _crytpoCoinService = crytpoCoinService;
        }

        //[HttpGet]
        //[Route("GetCoinMarketCapAll")]
        //public async Task<CryptoCoinResponse> GetCoinMarketCapByAll(CryptoCoinRequest request)
        //{
        //    var response = await _crytpoCoinService.GetCoinMarketCapByAll(request);
        //    return response;
        //}

        [HttpGet]
        [Route("GetCoinMarketCapLimit")]
        public CryptoCoinResponse GetCoinMarketCapByLimit(CryptoCoinRequest request)
        {
            var response = _crytpoCoinService.GetCoinMarketCapByLimit(request);
            return response;
        }

    }
}
