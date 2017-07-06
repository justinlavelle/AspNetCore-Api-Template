using HC.Template.Domain.Models;
using HC.Template.Infrastructure.Adapters;
using HC.Template.Infrastructure.Base;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Repo
{
    public class TestRepo: BaseRepo, ITestRepo
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection;

        public TestRepo (IDbConnection connection, IDbTransaction transaction, ConnectionStrings connectionStrings) : base(connectionStrings)
        {
            _connection = connection;
            _transaction = transaction;
        }
        
        public IEnumerable<TestObj1> GetDynamicSqlRecord()
        {
            var sqlCmd = "select 'TestField1' as 'Field1', 'TestField2' as 'Field2', 'TestField3' as 'Field3', 'TestField4' as 'Field4' ";

            var response = DapperRepo.ExecuteDynamicSql<TestObj1>(
                sql: sqlCmd,
                dbconnectionString: DefaultConnectionString, //_connectionSettings.Conn1,
                sqltimeout: DefaultTimeOut,
                dbconnection: _connection,
                dbtransaction: _transaction);

            return response;
        }

        public IEnumerable<TestObj2> GetStoredProcRecord(int supportRepId, string country)
        {
            var sqlStoredProc = "sp_get_Customer"; // find this stored proc inside this project: Infrastructure => Assets => Database => 02. STORED PROCEDURES [TestDB].sql

            var response = DapperRepo.GetFromStoredProc<TestObj2>
                   (storedProcedureName: sqlStoredProc,
                                              parameters: new
                                              {
                                                  SupportRepId = supportRepId,
                                                  Country = country
                                              },

                    dbconnectionString: DefaultConnectionString,
                    sqltimeout: DefaultTimeOut,
                    dbconnection: _connection,
                    dbtransaction: _transaction);

            return response;

        }

        public IEnumerable<TestObj3> InsertTestRecord(string ArtistName)
        {
            var sqlStoredProc = "sp_insert_Artist";

            throw new NotImplementedException();
        }
    }
}
