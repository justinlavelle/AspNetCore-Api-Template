using HC.Template.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Contracts
{
    public interface ITestRepo
    {
        Task<IEnumerable<TestObj>> GetTestRecord();
    }

}