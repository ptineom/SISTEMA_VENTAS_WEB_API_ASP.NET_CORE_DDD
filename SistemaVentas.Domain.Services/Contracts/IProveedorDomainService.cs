using SistemaVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.Services.Contracts
{
    public interface IProveedorDomainService: IBaseDomainService<Proveedor>, IProveedorDomainExtention<Proveedor>
    {

    }
}
