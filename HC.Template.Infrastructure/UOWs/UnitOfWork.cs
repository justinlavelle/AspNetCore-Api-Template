using System;
using System.Data;
using System.Data.SqlClient;
using HC.Template.Infrastructure.Base;
using HC.Template.Infrastructure.ConfigModels;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
using HC.Template.Infrastructure.Repositories.HealthCheck.Repo;
using HC.Template.Infrastructure.UOWs.Contracts;
using HC.Template.Infrastructure.Repositories.CryptoCurrency.Contracts;
using HC.Template.Infrastructure.Repositories.CryptoCurrency.Repo;

namespace HC.Template.Infrastructure.UOWs
{
    public class UnitOfWork: BaseUow, IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private ITestRepo _testRepo;
        //private IDBCheckRepo _dbCheckRepo;
        //private IStatusCheckRepo _statusCheckRepo;

        private bool _disposed;
        private ConnectionStrings _connectionSettings;

        public UnitOfWork(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
            _connectionSettings = connectionStrings;

            var connString = DefaultUowConnectionString;

            // Setup Connection & Transaction
            _connection = new SqlConnection(connString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public ITestRepo TestRepo
        {
            get { return _testRepo ?? (_testRepo = new TestRepo(_connection, _transaction, _connectionSettings)); }
        }

        public IDBCheckRepo DbRepo => throw new NotImplementedException();

        public IStatusCheckRepo StatusCheckRepo => throw new NotImplementedException();

        private void ResetRepositories()
        {
            _testRepo = null;
        }

        public bool Commit()
        {
            try
            {
                _transaction.Commit();

                return true;
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }


        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
