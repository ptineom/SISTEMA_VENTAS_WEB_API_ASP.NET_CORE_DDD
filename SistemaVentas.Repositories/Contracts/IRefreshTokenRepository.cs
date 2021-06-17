using SistemaVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.RepositoriesContracts.Contracts
{
    public interface IRefreshTokenRepository
    {
        Task<bool> RegisterAsync(RefreshToken obj, IDbTransaction transaction = null);
        Task<RefreshToken> GetByIdAsync(string idRefreshToken);
    }
}
