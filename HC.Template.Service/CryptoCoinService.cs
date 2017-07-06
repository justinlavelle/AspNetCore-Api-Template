using HC.Template.Infrastructure.Repositories.CryptoCurrency.Contracts;
using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels.CryptoCurrency;
using HC.Template.Service.InternalServices.Mappers.Contracts;

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

        public CryptoCoinResponse GetCoinMarketCapByLimit(CryptoCoinRequest request)
        {
            var capCoinRequest = _mapper.MapCryptoCoinRequestToCoinCapRequest(request);
            var response = _cryptoRepo.GetCoinCapData(capCoinRequest);
            var result = _mapper.MapCoinCapResponseToCryptoCoinResponse(response);

            return result;
        }
    }
}
