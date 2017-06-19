using Newtonsoft.Json;

namespace HC.Template.Interface.ServiceModels.CryptoCurrency
{
    public class CryptoCoinRequest
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("convert")]
        public string Convert { get; set; }
    }
}
