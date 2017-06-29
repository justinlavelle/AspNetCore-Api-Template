using HC.Template.Domain.Models.CryptoCurrency;
using HC.Template.Infrastructure.Base;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Infrastructure.Factories;
using HC.Template.Infrastructure.Factories.Contracts;
using HC.Template.Infrastructure.Repositories.CryptoCurrency.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.CryptoCurrency.Repo
{
    public class CryptoRepo: BaseRepo, ICryptoRepo
    {
        protected ServicesEndpoints _serviceEndpoints { get; }
        
        private readonly IHttpClientFactory _httpClientFactory;

        public CryptoRepo(IHttpClientFactory httpClientFactory, ServicesEndpoints serviceEndpoints, ConnectionStrings connectionStrings) : base(connectionStrings)
        {
            _httpClientFactory = httpClientFactory;
            _serviceEndpoints = serviceEndpoints;
        }

        public CoinCapResponse GetCoinCapData(CoinCapRequest coinCapRequest)
        {
            var serviceUrl = _serviceEndpoints.Services["CryptoCoinService"].Url;
            var httpClient = _httpClientFactory.Create(serviceUrl);

            //var stringContent = new StringContent(JsonConvert.SerializeObject(coinCapRequest), Encoding.UTF8, "application/json");
            //var response = await httpClient.PostAsync(baseAddress, stringContent);

            var baseAddress = new Uri(serviceUrl);
            UriBuilder serviceUri = new UriBuilder(baseAddress);
            serviceUri.Query = "limit=" + coinCapRequest.Limit + "&convert="+ coinCapRequest.Convert;

            var response = httpClient.GetAsync(serviceUri.Uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;

                var dataList = JsonConvert.DeserializeObject<List<CapCoinInfo>>(responseData);
                var result = new CoinCapResponse();
                result.Coins = dataList.AsEnumerable();

                return result;
            }

            return new CoinCapResponse();
        }
    }
}
