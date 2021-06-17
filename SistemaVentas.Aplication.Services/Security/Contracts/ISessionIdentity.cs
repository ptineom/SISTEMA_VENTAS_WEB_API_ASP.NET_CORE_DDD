using SistemaVentas.Aplication.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentas.Aplication.Services.Security.Contracts
{
    public interface ISessionIdentity
    {
        bool ExistUserInSession();
        UsuarioIdentityDTOResponse GetUserLogged();
    }
}
