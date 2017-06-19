using Newtonsoft.Json;
using System.Collections.Generic;

namespace HC.Template.Domain.Models.CryptoCurrency
{
    /*
     *  Sample Data:
     *  -----------------------------------------
        "id"                    : "bitcoin", 
        "name"                  : "Bitcoin", 
        "symbol"                : "BTC", 
        "rank"                  : "1", 
        "price_usd"             : "2561.27", 
        "price_btc"             : "1.0", 
        "24h_volume_usd"        : "1131920000.0", 
        "market_cap_usd"        : "42003065846.0", 
        "available_supply"      : "16399312.0", 
        "total_supply"          : "16399312.0", 
        "percent_change_1h"     : "-1.32", 
        "percent_change_24h"    : "-1.08", 
        "percent_change_7d"     : "-10.68", 
        "last_updated"          : "1497866058" 
     *  -----------------------------------------
     */

    public class CoinCapResponse
    {
        public IEnumerable<CapCoinInfo> Coins { get; set; }
    }

    public class CapCoinInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("rank")]
        public string Rank { get; set; }
        [JsonProperty("price_usd")]
        public string Price_usd { get; set; }
        [JsonProperty("price_btc")]
        public string Price_btc { get; set; }
        [JsonProperty("24h_volume_usd")]
        public string volume_usd_24H { get; set; }
        [JsonProperty("market_cap_usd")]
        public string Market_cap_usd { get; set; }
        [JsonProperty("available_supply")]
        public string Available_supply { get; set; }
        [JsonProperty("total_supply")]
        public string Total_supply { get; set; }
        [JsonProperty("percent_change_1h")]
        public string Percent_change_1h { get; set; }
        [JsonProperty("percent_change_24h")]
        public string Percent_change_24h { get; set; }
        [JsonProperty("percent_change_7d")]
        public string Percent_change_7d { get; set; }
        [JsonProperty("last_updated")]
        public string Last_updated { get; set; }
    }
}
