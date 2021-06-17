using SistemaVentas.Cross.Utils.DTOGeneric;
using SistemaVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.Services.Contracts
{
    public interface IRefreshTokenDomainService
    {
        Task<ResponseObject> RegisterAsync(RefreshToken obj);
        Task<RefreshToken> GetByIdAsync(string idRefreshToken);
    }
}
