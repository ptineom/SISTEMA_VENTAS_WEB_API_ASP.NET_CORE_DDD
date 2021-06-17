using SistemaVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.RepositoriesContracts.Contracts
{
    public interface ISecurityRepository
    {
        Task<Usuario> UserValidateAsync(string userId, string password, bool noValidar = false);
        Task<List<Sucursal>> GetCampusByUserIdAsync(string userId);
    }
}
