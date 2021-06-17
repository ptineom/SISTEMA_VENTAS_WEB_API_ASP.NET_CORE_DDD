using SistemaVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.Domain.RepositoriesContracts.Contracts
{
    public interface IClienteRepository : IBaseRepository<Cliente>, IClienteExtention
    {
    }
}
