using SistemaVentas.Aplication.DTO.Request;
using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Cross.Utils.DTOGeneric;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Aplication.Services.Security.Contracts
{
    public interface IRefreshTokenService
    {
        Task<ResponseObject> RegisterAsync(RefreshTokenDTORequest obj);
        Task<RefreshTokenDTOResponse> GetByIdAsync(string idRefreshToken);

    }
}
