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
using System.Data;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Repo
{
    public class TestRepo: BaseRepo, ITestRepo
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection;

        public TestRepo (IDbConnection connection, IDbTransaction transaction) : base()
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<IEnumerable<TestObj1>> GetDynamicSqlRecord()
        {
            var sqlCmd = "select 'TestField1' as 'Field1', 'TestField2' as 'Field2', 'TestField3' as 'Field3', 'TestField4' as 'Field4' ";

            return await DapperRepo.ExecuteDynamicSql<TestObj1>(
                sql: sqlCmd,
                dbconnectionString: DefaultConnectionString, //_connectionSettings.Conn1,
                sqltimeout: DefaultTimeOut,
                dbconnection: _connection,
                dbtransaction: _transaction)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<TestObj2>> GetStoredProcRecord()
        {
            var response = await DapperRepo.GetFromStoredProc<TestObj2>
                   (storedProcedureName: "hc_thirdparty_auto_get",
                    dbconnectionString: DefaultConnectionString, //_connectionSettings.Conn1,
                    sqltimeout: DefaultTimeOut,
                    dbconnection: _connection,
                    dbtransaction: _transaction)
                    .ConfigureAwait(false);
            return response;

        }
    }
}
