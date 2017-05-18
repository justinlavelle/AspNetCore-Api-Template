using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Adapters
{
    public class DapperRepo
    {
        private static IDbConnection OpenDBConnection(
            string connectionString = null,
            IDbConnection connection = null)
        {
            if ((string.IsNullOrWhiteSpace(connectionString)) && (connection == null))
            {
                throw new ArgumentException("ConnectionString and Connection cannot both be null!");
            }

            if (connection != null)
            {
                return connection;
            }

            // Connection Pooling enabled by default, MARS (Multiple active record sets) not enabled           
            return new SqlConnection(connectionString);
        }

        private static int GetSqlTimeOut(int? timeout = null)
        {
            return timeout.Value;
        }

        public static async Task<IEnumerable<T>> GetFromStoredProc<T>(
            string storedProcedureName,
            object parameters = null,
            string dbconnectionString = null,
            IDbConnection dbconnection = null,
            int? sqltimeout = null,
            IDbTransaction dbtransaction = null)
        {
            using (var connection = OpenDBConnection(dbconnectionString, dbconnection))
            {
                return await connection.QueryAsync<T>
                (
                    sql: storedProcedureName,
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    transaction: dbtransaction,
                    commandTimeout: GetSqlTimeOut(sqltimeout)
                ).ConfigureAwait(false);
            }
        }

        public static async Task<int> ExecuteAsStoredProc(
            string storedProcedureName,
            object parameters = null,
            string dbconnectionString = null,
            IDbConnection dbconnection = null,
            int? sqltimeout = null,
            IDbTransaction dbtransaction = null)
        {
            DynamicParameters p = new DynamicParameters(parameters);
            p.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (var connection = OpenDBConnection(dbconnectionString, dbconnection))
            {
                await connection.ExecuteAsync
                (
                    sql: storedProcedureName,
                    param: p,
                    commandType: CommandType.StoredProcedure,
                    transaction: dbtransaction,
                    commandTimeout: GetSqlTimeOut(sqltimeout)
                ).ConfigureAwait(false);
            }

            return p.Get<int>("@ReturnValue");
        }

        public static async Task<Dictionary<string, object>> ExecuteAsStoredProcWithOutput(
                string storedProcedureName,
                object inputParameters = null,
                IEnumerable<string> outputParameters = null,
                string dbconnectionString = null,
                IDbConnection dbconnection = null,
                int? sqltimeout = null,
                IDbTransaction dbtransaction = null)
        {
            // Parameters
            DynamicParameters p = new DynamicParameters();
            p.AddDynamicParams(inputParameters);
            // setup output parameters
            foreach (var par in outputParameters)
            {
                p.Add(par, null, null, ParameterDirection.Output, -1);
            }
            p.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (var connection = OpenDBConnection(dbconnectionString, dbconnection))
            {
                await connection.ExecuteAsync
                (
                    sql: storedProcedureName,
                    param: p,
                    commandType: CommandType.StoredProcedure,
                    transaction: dbtransaction,
                    commandTimeout: GetSqlTimeOut(sqltimeout)
                ).ConfigureAwait(false);
            }
            // add values from output parameters to dictionary
            Dictionary<string, object> returnOutputParameter = new Dictionary<string, object>();
            foreach (var param in outputParameters)
            {
                returnOutputParameter.Add(param, p.Get<dynamic>(param));
            }
            returnOutputParameter.Add("ReturnValue", p.Get<int>("@ReturnValue"));

            return returnOutputParameter;
        }
    }
}
