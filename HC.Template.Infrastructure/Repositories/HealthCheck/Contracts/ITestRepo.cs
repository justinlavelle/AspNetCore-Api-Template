using HC.Template.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Contracts
{
    public interface ITestRepo
    {
        Task<IEnumerable<TestObj1>> GetDynamicSqlRecord();
        Task<IEnumerable<TestObj2>> GetStoredProcRecord(int Param1, bool Param2);
    }

}