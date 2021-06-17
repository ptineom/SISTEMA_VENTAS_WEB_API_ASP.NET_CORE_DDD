using Microsoft.AspNetCore.Http;
using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Aplication.Services.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemaVentas.Aplication.Services.Security.Implementations
{
    public class SessionIdentity : ISessionIdentity
    {
        private IHttpContextAccessor _accessor;

        public SessionIdentity(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool ExistUserInSession()
        {
            bool bExiste = false;

            if (_accessor.HttpContext.User != null)
            {
                bExiste = _accessor.HttpContext.User.Identity.IsAuthenticated;
            }

            return bExiste;
        }

        public UsuarioIdentityDTOResponse GetUserLogged()
        {

            UsuarioIdentityDTOResponse modelo = null;
            if (_accessor.HttpContext.User != null && _accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                ClaimsIdentity identity = (ClaimsIdentity)_accessor.HttpContext.User.Identity;
                if (identity != null)
                {
                    var claims = identity.Claims;
                    modelo = new UsuarioIdentityDTOResponse
                    {
                        IdUsuario = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value,
                        NomUsuario = claims.FirstOrDefault(x => x.Type == "FullName").Value,
                        NomRol = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value,
                        IdSucursal = claims.FirstOrDefault(x => x.Type == "IdSucursal").Value,
                        FlgCtrlTotal = Convert.ToBoolean(claims.FirstOrDefault(x => x.Type == "FlgCtrlTotal").Value),
                        NameIdentifier = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value
                    };
                }
            }
            return modelo;
        }

    }
}
