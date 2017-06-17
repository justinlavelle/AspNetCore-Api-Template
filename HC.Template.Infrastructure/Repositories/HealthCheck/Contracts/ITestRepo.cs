using HC.Template.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Contracts
{
    public interface ITestRepo
    {
        Task<IEnumerable<TestObj1>> GetDynamicSqlRecord();
        Task<IEnumerable<TestObj2>> GetStoredProcRecord(int supportRepId, string country);
        Task<IEnumerable<TestObj3>> InsertTestRecord(string artistName);
    }

}