using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.RepositoriesContracts.Contracts
{
    public interface IBaseRepository<T> where T:class
    {
        Task<T> GetByIdAsync(string id);
        Task<List<T>> GetAllAsync(T obj);
        Task<bool> RegisterAsync(T obj, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(T obj, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(T obj, IDbTransaction transaction = null);
    }
}
