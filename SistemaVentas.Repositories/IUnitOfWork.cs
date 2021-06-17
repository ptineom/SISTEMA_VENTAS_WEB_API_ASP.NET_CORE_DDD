using SistemaVentas.Domain.RepositoriesContracts.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaVentas.Domain.RepositoriesContracts
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        IDbTransaction Transaction { get; }
        IProveedorRepository ProveedorRepository { get; }
    }
}
