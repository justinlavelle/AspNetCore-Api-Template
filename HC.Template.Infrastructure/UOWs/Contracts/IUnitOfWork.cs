using System;
using System.Collections.Generic;
using System.Text;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;

namespace HC.Template.Infrastructure.UOWs.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        ITestRepo TestRepo { get; }
        IDBCheckRepo DbRepo { get; }
        IStatusCheckRepo StatusCheckRepo { get; }

        bool Commit();
    }
}
