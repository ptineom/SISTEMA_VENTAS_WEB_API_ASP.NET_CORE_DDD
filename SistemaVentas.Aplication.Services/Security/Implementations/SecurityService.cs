using AutoMapper;
using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Aplication.Services.Security.Contracts;
using SistemaVentas.Cross.Utils;
using SistemaVentas.Cross.Utils.DTOGeneric;
using SistemaVentas.Domain.Entities;
using SistemaVentas.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Aplication.Services.Security.Implementations
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityDomainService _securityDomainService;
        private IMapper _mapper;
        public SecurityService(ISecurityDomainService securityDomainService, IMapper mapper)
        {
            _securityDomainService = securityDomainService;
            _mapper = mapper;
        }
        public async Task<List<SucursalDTOResponse>> GetCampusByUserIdAsync(string userId)
        {
            var list = await _securityDomainService.GetCampusByUserIdAsync(userId);
            var response = _mapper.Map<List<SucursalDTOResponse>>(list);
            return response;
        }

        public async Task<ResponseObject> UserValidationAsync(string userId, string password)
        {
            string passwordHash256 = Encode.GetHash256(password);
            ResponseObject result = await _securityDomainService.UserValidateAsync(userId, passwordHash256);

            UsuarioAuthDTOResponse response = _mapper.Map<UsuarioAuthDTOResponse>((Usuario)result.Data);
            result.Data = response;

            return result;
        }
    }
}
