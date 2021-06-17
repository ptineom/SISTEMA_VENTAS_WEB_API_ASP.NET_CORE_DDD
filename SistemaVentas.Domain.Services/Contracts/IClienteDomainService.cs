using SistemaVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.Domain.Services.Contracts
{
    public interface IClienteDomainService: IBaseDomainService<Cliente>, IClienteDomainExtention<Cliente>
    {
    }
}
