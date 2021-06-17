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
    public class RefreshTokenDomainService : IRefreshTokenDomainService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public RefreshTokenDomainService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> GetByIdAsync(string idRefreshToken)
        {
            return await _refreshTokenRepository.GetByIdAsync(idRefreshToken);
        }
        public async Task<ResponseObject> RegisterAsync(RefreshToken obj)
        {
            try
            {
                await _refreshTokenRepository.RegisterAsync(obj);
                return new ResponseObject() { Message = Generales.INSERT_SUCCESS};
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    Success = false,
                    Message = Generales.INSERT_ERROR,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = 500,
                        Message = ex.Message
                    }
                };
            }
        }
    }
}
