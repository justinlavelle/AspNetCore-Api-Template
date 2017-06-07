using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
using HC.Template.Domain.Models;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Repo
{

    /// <summary>
    /// Service Status Middleware used to check the Health of your service.
    /// </summary>
    public class StatusCheckRepo: IStatusCheckRepo
    {
        public Task Ping(HttpContext httpContext)
        {
            return WriteResponseAsync(httpContext, HttpStatusCode.OK, new ServiceStatus(true));
        }

        /// <summary>
        /// Writes a response of the Service Status Check.
        /// </summary>
        /// <param name="httpContext">The HttpContext.</param>
        /// <param name="httpStatusCode">The http status to return.!--.</param>
        /// <param name="serviceStatus">The status</param>
        /// <returns>Task</returns>
        private Task WriteResponseAsync(HttpContext httpContext, HttpStatusCode httpStatusCode, ServiceStatus serviceStatus)
        {
            // Set content type.
            httpContext.Response.Headers["Content-Type"] = new[] { "application/json" };

            // Minimum set of headers to disable caching of the response.
            httpContext.Response.Headers["Cache-Control"] = new[] { "no-cache, no-store, must-revalidate" };
            httpContext.Response.Headers["Pragma"] = new[] { "no-cache" };
            httpContext.Response.Headers["Expires"] = new[] { "0" };

            // Set status code.
            httpContext.Response.StatusCode = (int)httpStatusCode;

            // Write the content.
            var content = JsonConvert.SerializeObject(serviceStatus);
            return httpContext.Response.WriteAsync(content);
        }
    }
}