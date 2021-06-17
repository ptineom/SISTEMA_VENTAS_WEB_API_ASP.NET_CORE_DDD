using SistemaVentas.Domain.RepositoriesContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SistemaVentas.Infrastructure.Repositories
{
    public sealed class Connection : IConnection, IDisposable
    {
        private IDbConnection _dbConnection;

        public Connection(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;

            if (_dbConnection == null)
                _dbConnection = new SqlConnection(_dbConnection.ConnectionString);

            _dbConnection.Close();

            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();
        }

        public IDbConnection DbConnection
        {
            get
            {
                return _dbConnection;
            }
        }

        public void CloseConnection()
        {
            if (_dbConnection != null && _dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
        public void Dispose()
        {
            CloseConnection();
        }
    }
}
