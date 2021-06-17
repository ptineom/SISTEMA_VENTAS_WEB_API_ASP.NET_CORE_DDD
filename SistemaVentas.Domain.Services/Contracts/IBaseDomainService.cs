using SistemaVentas.Cross.Utils.DTOGeneric;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.Services.Contracts
{
    public interface IBaseDomainService<T> where T: class
    {
        Task<ResponseObject> RegisterAsync(T obj);
        Task<ResponseObject> UpdateAsync(T obj);
        Task<ResponseObject> DeleteAsync(T obj);
        Task<List<T>> GetAllAsync(T obj);
        Task<T> GetByIdAsync(string id);
    }
}
