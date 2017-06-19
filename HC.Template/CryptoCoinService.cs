using HC.Template.Infrastructure.Repositories.CryptoCurrency.Contracts;
using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels.CryptoCurrency;
using HC.Template.InternalServices.Mappers.Contracts;
using System;
using System.Threading.Tasks;

namespace HC.Template.Service
{
    public class CryptoCoinService : ICryptoCoinService
    {
        private ICryptoRepo _cryptoRepo;
        private ICryptoCoinMapper _mapper;

        public CryptoCoinService(ICryptoCoinMapper mapper, ICryptoRepo cryptoRepo)
        {
            _mapper = mapper;
            _cryptoRepo = cryptoRepo;
        }

        /// <summary>
        /// Gets data from the external service provided by https://coinmarketcap.com/
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CryptoCoinResponse> GetCoinMarketCapByAll(CryptoCoinRequest request)
        {
            var capCoinRequest = _mapper.MapCryptoCoinRequestToCoinCapRequest(request);
            var response = await _cryptoRepo.GetCoinCapData(capCoinRequest);
            var result = _mapper.MapCoinCapResponseToCryptoCoinResponse(response);

            return result;
        }

        public async Task<CryptoCoinResponse> GetCoinMarketCapByLimit(CryptoCoinRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
