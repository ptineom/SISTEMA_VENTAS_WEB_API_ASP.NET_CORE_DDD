using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.Services.Contracts
{
    public interface IClienteDomainExtention<T> where T : class
    {
        Task<T> GetByDocument(T obj);
    }
}
