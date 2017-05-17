using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
using System;
using System.Threading.Tasks;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Repo
{
    public class DatabaseRepo : IDatabaseCheck
    {
        public Task<string> Check()
        {
            throw new NotImplementedException();
        }

        private string connectionString;
        public DatabaseRepo()
        {
            connectionString = @"Server=localhost;Database=DapperDemo;Trusted_Connection=true;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public void GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Products"
                               + " WHERE ProductId = @Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

    }
}
