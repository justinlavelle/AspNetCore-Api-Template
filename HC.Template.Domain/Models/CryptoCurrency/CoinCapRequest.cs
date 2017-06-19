using Newtonsoft.Json;

namespace HC.Template.Domain.Models.CryptoCurrency
{
    public class CoinCapRequest
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("convert")]
        public string Convert { get; set; }
    }
}
