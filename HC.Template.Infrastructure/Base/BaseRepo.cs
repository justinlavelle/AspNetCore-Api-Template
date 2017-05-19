using HC.Template.Infrastructure.ConfigModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Data.SqlClient;

namespace HC.Template.Infrastructure.Base
{
    public class BaseRepo
    {
        private IConfiguration config;
        protected ConnectionStrings connectionStrings { get; }

        public BaseRepo(ConnectionStrings conSettings)
        {
            connectionStrings = conSettings;    // Strongly-Typed settings
        }

        protected string DefaultConnectionString
        {
            get
            {
                return connectionStrings.Conn1; // specifies a specific connection string
            }
        }

        protected int DefaultTimeOut
        {
            get
            {
                return connectionStrings.Timeout;
            }
        }

    }
}
