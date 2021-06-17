using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Cross.Utils.DTOGeneric;
using SistemaVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Aplication.Services.Security.Contracts
{
    public interface ISecurityService
    {
        Task<ResponseObject> UserValidationAsync(string userId, string password);
        Task<List<SucursalDTOResponse>> GetCampusByUserIdAsync(string userId);
    }
}
