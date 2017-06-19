using Newtonsoft.Json;
using System.Collections.Generic;

namespace HC.Template.Interface.ServiceModels.CryptoCurrency
{
    public class CryptoCoinResponse
    {
        public IEnumerable<CryptoCoinInfo> Coins { get; set; }
    }

    public class CryptoCoinInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("price_usd")]
        public decimal Price_usd { get; set; }
        [JsonProperty("price_btc")]
        public decimal Price_btc { get; set; }
        [JsonProperty("24h_volume_usd")]
        public decimal volume_usd_24H { get; set; }
        [JsonProperty("market_cap_usd")]
        public decimal Market_cap_usd { get; set; }
        [JsonProperty("available_supply")]
        public decimal Available_supply { get; set; }
        [JsonProperty("total_supply")]
        public decimal Total_supply { get; set; }
        [JsonProperty("percent_change_1h")]
        public decimal Percent_change_1h { get; set; }
        [JsonProperty("percent_change_24h")]
        public decimal Percent_change_24h { get; set; }
        [JsonProperty("percent_change_7d")]
        public decimal Percent_change_7d { get; set; }
        [JsonProperty("last_updated")]
        public int Last_updated { get; set; }
    }
}
