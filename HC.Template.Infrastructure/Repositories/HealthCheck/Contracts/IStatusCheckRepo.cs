using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Contracts
{
    public interface IStatusCheckRepo
    {
        Task Ping(HttpContext httpContext);
    }
}
