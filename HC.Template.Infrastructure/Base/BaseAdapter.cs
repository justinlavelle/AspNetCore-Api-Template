using HC.Template.Infrastructure.ConfigModels;
using Microsoft.Extensions.Configuration;

namespace HC.Template.Infrastructure.Base
{
    public abstract class BaseAdapter
    {
        private IConfiguration config;
        private readonly ConnectionStrings _connectionStrings;

        public BaseAdapter(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        protected string DefaultConnectionString
        {
            get
            {
                return _connectionStrings.Conn1; // specifies a specific connection string
            }
        }

        protected int DefaultTimeOut
        {
            get
            {
                return _connectionStrings.Timeout;
            }
        }

    }
}