using RepositoyPattern.Infra.Infra;
using System.Data;
using System.Data.SqlClient;

namespace RepositoyPattern.Infra
{
    public class MSSQLServer : IDB
    {
        private IDbConnection _db;
        private IInfraConfiguration _dbConfig;

        public MSSQLServer(IInfraConfiguration dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public void Dispose()
        {
            _db.Close();
            _db.Dispose();
        }
        public IDbConnection GetConnection()
        {
            if (_db != null)
                return _db;
            else
                return _db = new SqlConnection(_dbConfig.ConnectionString);
        }
    }
}
