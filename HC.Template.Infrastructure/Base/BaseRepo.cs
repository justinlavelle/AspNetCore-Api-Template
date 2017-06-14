using HC.Template.Infrastructure.ConfigModels;
using Microsoft.Extensions.Configuration;

namespace HC.Template.Infrastructure.Base
{
    public abstract class BaseRepo
    {
        private IConfiguration config;
        private readonly ConnectionStrings _connectionStrings;

        public BaseRepo(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        protected virtual string DefaultConnectionString
        {
            get
            {
                return _connectionStrings.Conn1; // specifies a specific connection string
            }
        }

        protected virtual int DefaultTimeOut
        {
            get
            {
                return _connectionStrings.Timeout;
            }
        }

    }
}