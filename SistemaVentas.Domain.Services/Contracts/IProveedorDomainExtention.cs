using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.Services.Contracts
{
    public interface IProveedorDomainExtention<T>
    {
        Task<T> GetByDocument(T obj);
    }
}
