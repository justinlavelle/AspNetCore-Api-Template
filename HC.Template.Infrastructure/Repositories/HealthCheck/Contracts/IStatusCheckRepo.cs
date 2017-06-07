using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Contracts
{
    public interface IStatusCheckRepo
    {
        Task Ping(HttpContext httpContext);
    }
}
