using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HC.Template.Infrastructure.Factories
{
    public sealed class HttpClientFactory : IDisposable    // Register as singleton
    {
        private readonly ConcurrentDictionary<Uri, HttpClient> _httpClients;

        public HttpClientFactory()
        {
            _httpClients = new ConcurrentDictionary<Uri, HttpClient>();
        }

        public HttpClient Create(Uri baseAddress)
        {
            var client = _httpClients.GetOrAdd(baseAddress,
                b => new HttpClient { BaseAddress = b });

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public void Dispose()
        {
            foreach (var httpClient in _httpClients.Values)
            {
                httpClient.Dispose();
            }
        }
    }
}
