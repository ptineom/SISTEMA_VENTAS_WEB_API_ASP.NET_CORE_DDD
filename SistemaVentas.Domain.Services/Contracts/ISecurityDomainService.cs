using SistemaVentas.Cross.Utils.DTOGeneric;
using SistemaVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.Services.Contracts
{
    public interface ISecurityDomainService
    {
        Task<ResponseObject> UserValidateAsync(string userId, string password, bool noValidar = false);
        Task<List<Sucursal>> GetCampusByUserIdAsync(string userId);
    }
}
