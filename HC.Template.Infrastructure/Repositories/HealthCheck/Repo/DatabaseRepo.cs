using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
using System;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Repo
{
    public class DatabaseRepo : IDatabaseCheck
    {
        public Task<string> Check()
        {
            throw new NotImplementedException();
        }
    }
}
