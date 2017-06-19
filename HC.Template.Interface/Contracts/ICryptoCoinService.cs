using HC.Template.Interface.ServiceModels.CryptoCurrency;
using System.Threading.Tasks;

namespace HC.Template.Interface.Contracts //Don't forget to add to Startup.cs for DI
{
    public interface ICryptoCoinService
    {
        Task<CryptoCoinResponse> GetCoinMarketCapByAll(CryptoCoinRequest request);
        Task<CryptoCoinResponse> GetCoinMarketCapByLimit(CryptoCoinRequest request);
    }
}
