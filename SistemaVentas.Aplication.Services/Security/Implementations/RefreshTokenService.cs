using AutoMapper;
using SistemaVentas.Aplication.DTO.Request;
using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Aplication.Services.Contracts;
using SistemaVentas.Aplication.Services.Security.Contracts;
using SistemaVentas.Cross.Utils.DTOGeneric;
using SistemaVentas.Domain.Entities;
using SistemaVentas.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Aplication.Services.Security.Implementations
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenDomainService _refreshTokenDomainService;
        private IMapper _mapper;
        public RefreshTokenService(IRefreshTokenDomainService refreshTokenDomainService, IMapper mapper)
        {
            _refreshTokenDomainService = refreshTokenDomainService;
            _mapper = mapper;
        }
        public async Task<RefreshTokenDTOResponse> GetByIdAsync(string idRefreshToken)
        {
            var result = await _refreshTokenDomainService.GetByIdAsync(idRefreshToken);
            var response = _mapper.Map<RefreshTokenDTOResponse>(result);
            return response;
        }

        public async Task<ResponseObject> RegisterAsync(RefreshTokenDTORequest obj)
        {
            var model = _mapper.Map<RefreshToken>(obj);
            return await _refreshTokenDomainService.RegisterAsync(model);
        }
    }
}
