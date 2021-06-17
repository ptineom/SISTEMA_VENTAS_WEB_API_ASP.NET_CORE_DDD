using SistemaVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.RepositoriesContracts.Contracts
{
    public interface IClienteExtention
    {
        Task<Cliente> GetByDocument(Cliente obj);
    }
}
