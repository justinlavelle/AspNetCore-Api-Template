using HC.Template.Domain.Models.CryptoCurrency;
using HC.Template.Infrastructure.Base;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Infrastructure.Factories;
using HC.Template.Infrastructure.Repositories.CryptoCurrency.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.CryptoCurrency.Repo
{
    public class CryptoRepo: BaseRepo, ICryptoRepo
    {
        protected ServicesEndpoints _serviceEndpoints { get; }
        protected AppSettings _appSettings { get; }
        private readonly HttpClientFactory _httpClientFactory;

        public CryptoRepo(HttpClientFactory httpClientFactory, ServicesEndpoints serviceEndpoints, ConnectionStrings connectionStrings) : base(connectionStrings)
        {
            _httpClientFactory = httpClientFactory;
            _serviceEndpoints = serviceEndpoints;
        }

        public async Task<CoinCapResponse> GetCoinCapData(CoinCapRequest coinCapRequest)
        {
            var serviceUrl = _serviceEndpoints.Services["CryptoCoinService"].Url;

            var baseAddress = new Uri(serviceUrl);
            var httpClient = _httpClientFactory.Create(baseAddress);

            //var stringContent = new StringContent(JsonConvert.SerializeObject(coinCapRequest), Encoding.UTF8, "application/json");
            //var response = await httpClient.PostAsync(baseAddress, stringContent);

            UriBuilder serviceUri = new UriBuilder(baseAddress);
            serviceUri.Query = "limit=" + coinCapRequest.Limit + "&convert="+ coinCapRequest.Convert;

            var response = await httpClient.GetAsync(serviceUri.Uri);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();

                var dataList = JsonConvert.DeserializeObject<List<CapCoinInfo>>(responseData);
                var result = new CoinCapResponse();
                result.Coins = dataList.AsEnumerable();

                return result;
            }

            return new CoinCapResponse();
        }

        public async Task<CoinCapResponse> GetCoinCapDataLimit(CoinCapRequest coinCapRequest)
        {
            var baseAddress = new Uri(_serviceEndpoints.Services["CryptoCoinService"].Url);
            var httpClient = _httpClientFactory.Create(baseAddress);

            var response = new CoinCapResponse();

            return response;
        }
    }
}
