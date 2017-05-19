using HC.Template.Domain.Models;
using HC.Template.Infrastructure.Adapters;
using HC.Template.Infrastructure.Base;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Repo
{
    public class TestRepo: BaseRepo, ITestRepo
    {
        private readonly ConnectionStrings _connectionSettings;
        private AppSettings _appSettings;
        public TestRepo (ConnectionStrings connString) : base(connString)
        {
            _connectionSettings = connString;
        }
        public async Task<IEnumerable<TestObj>> GetTestRecord()
        {
            var sqlCmd = "Select 'TestField1' as 'Field1'," +
                         "       'TestField2' as 'Field2'" +
                         "       'TestField3' as 'Field3'" +
                         "       'TestField4' as 'Field4'";

            return await DapperRepo.ExecuteDynamicSql<TestObj>(
                sql: sqlCmd,
                dbconnectionString: _connectionSettings.Conn1,
                sqltimeout: _connectionSettings.Timeout)
                .ConfigureAwait(false);                
        }

    }
}
