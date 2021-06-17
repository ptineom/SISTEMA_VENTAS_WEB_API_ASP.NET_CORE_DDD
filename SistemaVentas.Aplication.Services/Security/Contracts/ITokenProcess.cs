using SistemaVentas.Aplication.DTO.Request;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SistemaVentas.Aplication.Services.Security.Contracts
{
    public interface ITokenProcess
    {
        IEnumerable<Claim> GenerateClaims(AuthDTORequest obj);
        string GenerateToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();

    }
}
