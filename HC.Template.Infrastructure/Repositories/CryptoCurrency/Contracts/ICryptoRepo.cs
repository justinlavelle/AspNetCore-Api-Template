using HC.Template.Domain.Models.CryptoCurrency;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.CryptoCurrency.Contracts
{
    public interface ICryptoRepo // Add to Startup.cs for DI
    {
        Task<CoinCapResponse> GetCoinCapData(CoinCapRequest coinCapRequest);
        Task<CoinCapResponse> GetCoinCapDataLimit(CoinCapRequest coinCapRequest);
    }
}
