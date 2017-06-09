using HC.Template.Infrastructure.ConfigModels;

namespace HC.Template.Infrastructure.Base
{
    public abstract class BaseAdapter
    {
        ConnectionStrings connectionStrings { get; }

        public BaseAdapter()
        {

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
