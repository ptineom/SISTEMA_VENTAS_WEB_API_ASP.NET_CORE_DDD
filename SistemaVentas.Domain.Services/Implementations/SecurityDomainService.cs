using SistemaVentas.Cross.Utils.Constantes;
using SistemaVentas.Cross.Utils.DTOGeneric;
using SistemaVentas.Domain.Entities;
using SistemaVentas.Domain.RepositoriesContracts.Contracts;
using SistemaVentas.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.Services.Implementations
{
    public class SecurityDomainService : ISecurityDomainService
    {
        private readonly ISecurityRepository _securityRepository;
        public SecurityDomainService(ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        public async Task<List<Sucursal>> GetCampusByUserIdAsync(string userId)
        {
            return await _securityRepository.GetCampusByUserIdAsync(userId);
        }

        public async Task<ResponseObject> UserValidateAsync(string userId, string password, bool noValidar = false)
        {
            try
            {
                Usuario response = await _securityRepository.UserValidateAsync(userId, password, noValidar);
                return new ResponseObject() { Data = response };
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    Success = false,
                    Message = Generales.NOT_FOUND,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = 404,
                        Message = ex.Message
                    }
                };
            }
        }
    }
}
