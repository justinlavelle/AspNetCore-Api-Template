using HC.Template.Domain.Models.CryptoCurrency;
using HC.Template.Interface.ServiceModels.CryptoCurrency;

namespace HC.Template.InternalServices.Mappers.Contracts
{
    public interface ICryptoCoinMapper// Make sure to map this in Startup.cs for Dependency Injection (DI)
    {
        CoinCapRequest MapCryptoCoinRequestToCoinCapRequest(CryptoCoinRequest request);
        CryptoCoinResponse MapCoinCapResponseToCryptoCoinResponse(CoinCapResponse response);
    }
}
