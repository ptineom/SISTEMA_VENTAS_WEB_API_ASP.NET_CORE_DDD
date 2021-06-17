using SistemaVentas.Domain.Entities;
using SistemaVentas.Domain.RepositoriesContracts;
using SistemaVentas.Domain.RepositoriesContracts.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Infrastructure.Repositories.Implementations
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly IConnection _connection;
        private readonly string _storeProcedure = "PA_MANT_MARCA";
        public MarcaRepository(IConnection connection)
        {
            _connection = connection;
        }
        public Task<bool> DeleteAsync(Marca obj, IDbTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<List<Marca>> GetAllAsync(Marca obj)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(Marca obj, IDbTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Marca obj, IDbTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
