using HC.Template.Domain.Models.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HC.Template.Domain.Base
{
    public class BaseRepo
    {
        private IConfiguration config;
        private ConnectionStrings connectionStrings;
        private ExternalServices externalServices;

        public BaseRepo(ConnectionStrings conSettings, ExternalServices serviceSettings)
        {
            connectionStrings = conSettings;    // Strongly-Typed settings
            externalServices = serviceSettings; // Strongly-Typed settings
        }

        private string _externalService;
        private string _connectionStringValue;

        protected string ExternalService
        {
            get
            {
                if (string.IsNullOrEmpty(_externalService))
                {
                    _externalService = externalServices.ExternalService1; //CustomerDM Account Service Web Api "";
                }
                return _externalService;
            }
        }

        protected string DefaultConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionStringValue))
                {
                    _connectionStringValue = connectionStrings.Conn1; // specifies a specific connection string
                }
               
                return _connectionStringValue;
            }
        }

    }
}
