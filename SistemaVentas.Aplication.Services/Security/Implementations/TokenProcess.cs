using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaVentas.Aplication.DTO.Request;
using SistemaVentas.Aplication.Services.Security.Contracts;
using SistemaVentas.Cross.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SistemaVentas.Aplication.Services.Security.Implementations
{
    public class TokenProcess : ITokenProcess
    {
        private IConfiguration _configuration;
        public TokenProcess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<Claim> GenerateClaims(AuthDTORequest obj)
        {
            // CREAMOS EL PAYLOAD //
            IEnumerable<Claim> _Claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, obj.NomRol),
                new Claim(ClaimTypes.Name, obj.IdUsuario),
                new Claim("IdUsuario", obj.IdUsuario),
                new Claim("FullName", obj.NomUsuario),
                new Claim("IdSucursal", obj.IdSucursal),
                new Claim("NomSucursal", obj.NomSucursal),
                new Claim("FlgCtrlTotal", obj.FlgCtrlTotal.ToString()),
                new Claim(ClaimTypes.NameIdentifier, obj.IdUsuario)
            };

            return _Claims;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var audienceToken = _configuration.GetSection("Jwt:AudienceToken").Value;
            var issuerToken = _configuration.GetSection("Jwt:IssuerToken").Value;
            var expireTime = _configuration.GetSection("Jwt:ExpireMinutes").Value;

            //Codifica el secretKey en hash256. Nota: el secretKey deberá tener como minimo 16 caracateres.
            var secretKey = Encode.GetHash256(_configuration.GetSection("Jwt:SecretKey").Value);

            // CREAMOS EL HEADER //
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var _Header = new JwtHeader(signingCredentials);

            var _Payload = new JwtPayload(
                    issuer: issuerToken,
                    audience: audienceToken,
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    // Expira
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime))
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
