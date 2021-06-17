using AutoMapper;
using SistemaVentas.Aplication.DTO.Request;
using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Aplication.Services.Contracts;
using SistemaVentas.Cross.Utils.DTOGeneric;
using SistemaVentas.Domain.Entities;
using SistemaVentas.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Aplication.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteDomainService _clienteDomainService;
        private IMapper _mapper;
        public ClienteService(IClienteDomainService clienteDomainService, IMapper mapper)
        {
            _clienteDomainService = clienteDomainService;
            _mapper = mapper;
        }
        public async Task<ResponseObject> DeleteAsync(ClienteDTORequest obj)
        {
            var model = _mapper.Map<Cliente>(obj);
            return await _clienteDomainService.DeleteAsync(model);
        }

        public async Task<List<ClienteDTOResponse>> GetAllAsync(ClienteDTORequest obj)
        {
            var model = _mapper.Map<Cliente>(obj);
            var result = await _clienteDomainService.GetAllAsync(model);
            var response = _mapper.Map<List<ClienteDTOResponse>>(result);
            return response;
        }

        public async Task<ClienteDTOResponse> GetByDocument(ClienteDTORequest obj)
        {
            var model = _mapper.Map<Cliente>(obj);
            var result = await _clienteDomainService.GetByDocument(model);
            var response = _mapper.Map<ClienteDTOResponse>(result);
            return response;
        }

        public async Task<ClienteDTOResponse> GetByIdAsync(string id)
        {
            var result = await _clienteDomainService.GetByIdAsync(id);
            var response = _mapper.Map<ClienteDTOResponse>(result);
            return response;
        }

        public async Task<ResponseObject> RegisterAsync(ClienteDTORequest obj)
        {
            var model = _mapper.Map<Cliente>(obj);

            return await _clienteDomainService.RegisterAsync(model);
        }

        public async Task<ResponseObject> UpdateAsync(ClienteDTORequest obj)
        {
            var model = _mapper.Map<Cliente>(obj);
            return await _clienteDomainService.UpdateAsync(model);
        }
    }
}
