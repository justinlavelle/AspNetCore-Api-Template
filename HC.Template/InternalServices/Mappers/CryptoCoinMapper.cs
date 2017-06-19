using HC.Template.Domain.Models.CryptoCurrency;
using HC.Template.Interface.ServiceModels.CryptoCurrency;
using HC.Template.InternalServices.Mappers.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HC.Template.InternalServices.Mappers // Internal services are never meant to be exposed to an external consumer. Hence Internal services
{
    public class CryptoCoinMapper : ICryptoCoinMapper
    {
        public CoinCapRequest MapCryptoCoinRequestToCoinCapRequest(CryptoCoinRequest request)
        {
            var result = new CoinCapRequest()
            {
                Convert = request.Convert,
                Limit = request.Limit
            };

            return result;
        }

        public CryptoCoinResponse MapCoinCapResponseToCryptoCoinResponse(CoinCapResponse response)
        {
            var result = new CryptoCoinResponse();

            // Mapping a list
            var coinList = new List<CryptoCoinInfo>();
            foreach (var coin in response.Coins)
            {
                var coinInfo = new CryptoCoinInfo()
                {
                    Available_supply = Convert.ToDecimal(coin.Available_supply),
                    Id = coin.Id,
                    Last_updated = Convert.ToInt32(coin.Last_updated),
                    Market_cap_usd = Convert.ToDecimal(coin.Market_cap_usd),
                    Name = coin.Name,
                    Percent_change_1h = Convert.ToDecimal(coin.Percent_change_1h),
                    Percent_change_24h = Convert.ToDecimal(coin.Percent_change_24h),
                    Percent_change_7d = Convert.ToDecimal(coin.Percent_change_7d),
                    Price_btc = Convert.ToDecimal(coin.Price_btc),
                    Price_usd = Convert.ToDecimal(coin.Price_usd),
                    Rank = Convert.ToInt32(coin.Rank),
                    Symbol = coin.Symbol,
                    Total_supply = Convert.ToDecimal(coin.Total_supply),
                    volume_usd_24H = Convert.ToDecimal(coin.volume_usd_24H)
                };
                coinList.Add(coinInfo);
            }

            result.Coins = coinList.AsEnumerable();

            return result;
        }
    }
}
