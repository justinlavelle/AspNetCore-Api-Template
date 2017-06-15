using System;
using System.Collections.Generic;
using System.Text;
using HC.Template.Infrastructure.ConfigModels;
using Microsoft.Extensions.Configuration;

namespace HC.Template.Infrastructure.Base
{
    public abstract class BaseUow
    {
        private readonly ConnectionStrings _connectionStrings;
        public BaseUow(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        protected virtual string DefaultUowConnectionString
        {
            get
            {
                return _connectionStrings.Conn1; // specifies a specific connection string
            }
        }
    }
}
