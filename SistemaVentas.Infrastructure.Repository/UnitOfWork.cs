using SistemaVentas.Domain.RepositoriesContracts;
using SistemaVentas.Domain.RepositoriesContracts.Contracts;
using SistemaVentas.Infrastructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaVentas.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IConnection _connection = null;
        private IDbTransaction _transaction;
        private IProveedorRepository _proveedorRepository;
        private ISecurityRepository _securityRepository;

        public UnitOfWork(IConnection connection)
        {
            _connection = connection;
        }
        public void BeginTransaction()
        {
            _transaction = _connection.DbConnection.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }
        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }
        public void Dispose() => _transaction?.Dispose();

        public IDbTransaction Transaction
        {
            get { return _transaction; }
        }
        public IProveedorRepository ProveedorRepository
        {
            get
            {
                return _proveedorRepository ?? (_proveedorRepository = new ProveedorRepository(_connection));
            }
        }

        public ISecurityRepository SecurityRepository
        {
            get
            {
                return _securityRepository ?? (_securityRepository = new SecurityRepository(_connection));
            }
        }
    }
}
