using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Contracts
{
    public interface IDBCheckRepo
    {
        Task<string> Check();
    }
}
