﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HC.Template.Infrastructure.Adapters
{
    public static class DapperRepo
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
            return new SqlConnection(connectionString); // Only if a connection object is not provided.
        }

        private static int GetSqlTimeOut(int? timeout = null)
        {
            return timeout.Value;
        }

        public static IEnumerable<T> GetFromStoredProc<T>(
            string storedProcedureName,
            object parameters = null,
            string dbconnectionString = null,
            IDbConnection dbconnection = null,
            int? sqltimeout = null,
            IDbTransaction dbtransaction = null)
        {
            var connection = OpenDBConnection(dbconnectionString, dbconnection);
            return connection.Query<T>
            (
                sql: storedProcedureName,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                transaction: dbtransaction,
                commandTimeout: GetSqlTimeOut(sqltimeout)
            );
        }

        public static int ExecuteAsStoredProc(
            string storedProcedureName,
            object parameters = null,
            string dbconnectionString = null,
            IDbConnection dbconnection = null,
            int? sqltimeout = null,
            IDbTransaction dbtransaction = null)
        {
            DynamicParameters p = new DynamicParameters(parameters);
            p.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            var connection = OpenDBConnection(dbconnectionString, dbconnection);
             connection.Execute
            (
                sql: storedProcedureName,
                param: p,
                commandType: CommandType.StoredProcedure,
                transaction: dbtransaction,
                commandTimeout: GetSqlTimeOut(sqltimeout)
            );

            return p.Get<int>("@ReturnValue");
        }

        public static Dictionary<string, object> ExecuteAsStoredProcWithOutput(
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

            var connection = OpenDBConnection(dbconnectionString, dbconnection);
            connection.Execute
            (
                sql: storedProcedureName,
                param: p,
                commandType: CommandType.StoredProcedure,
                transaction: dbtransaction,
                commandTimeout: GetSqlTimeOut(sqltimeout)
            );

            // add values from output parameters to dictionary
            Dictionary<string, object> returnOutputParameter = new Dictionary<string, object>();
            foreach (var param in outputParameters)
            {
                returnOutputParameter.Add(param, p.Get<dynamic>(param));
            }
            returnOutputParameter.Add("ReturnValue", p.Get<int>("@ReturnValue"));

            return returnOutputParameter;
        }

        public static IEnumerable<T> ExecuteDynamicSql<T>(
                string sql,
                string dbconnectionString = null,
                IDbConnection dbconnection = null,
                int? sqltimeout = null,
                IDbTransaction dbtransaction = null)
        {
            var connection = OpenDBConnection(dbconnectionString, dbconnection);
            return connection.Query<T>
            (
                sql: sql,
                commandType: CommandType.Text,
                transaction: dbtransaction,
                commandTimeout: GetSqlTimeOut(sqltimeout)
            );
        }
    }
}
