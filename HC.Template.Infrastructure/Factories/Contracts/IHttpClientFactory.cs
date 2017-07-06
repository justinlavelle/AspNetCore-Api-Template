using System;
using System.Net.Http;

namespace HC.Template.Infrastructure.Factories.Contracts
{
    public interface IHttpClientFactory : IDisposable
    {
        HttpClient Create(string baseAddress);

    }
}
