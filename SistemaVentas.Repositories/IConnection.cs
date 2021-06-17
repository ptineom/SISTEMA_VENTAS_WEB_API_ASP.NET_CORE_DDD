using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaVentas.Domain.RepositoriesContracts
{
    public interface IConnection
    {
        IDbConnection DbConnection { get; }
        void CloseConnection();
    }
}
