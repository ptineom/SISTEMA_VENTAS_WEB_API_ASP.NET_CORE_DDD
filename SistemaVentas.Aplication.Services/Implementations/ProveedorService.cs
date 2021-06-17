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
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorDomainService _proveedorDomainService;
        private IMapper _mapper;
        public ProveedorService(IProveedorDomainService proveedorDomainService, IMapper mapper)
        {
            _proveedorDomainService = proveedorDomainService;
            _mapper = mapper;
        }

        public async Task<ResponseObject> RegisterAsync(ProveedorDTORequest obj)
        {
            var model = _mapper.Map<Proveedor>(obj);

            return await _proveedorDomainService.RegisterAsync(model);
        }
        public async Task<ResponseObject> UpdateAsync(ProveedorDTORequest obj)
        {
            var model = _mapper.Map<Proveedor>(obj);
            return await _proveedorDomainService.UpdateAsync(model);
        }
        public async Task<ResponseObject> DeleteAsync(ProveedorDTORequest obj)
        {
            var model = _mapper.Map<Proveedor>(obj);
            return await _proveedorDomainService.DeleteAsync(model);
        }

        public async Task<List<ProveedorDTOResponse>> GetAllAsync(ProveedorDTORequest obj)
        {
            var model = _mapper.Map<Proveedor>(obj);
            var result = await _proveedorDomainService.GetAllAsync(model);
            var response = _mapper.Map<List<ProveedorDTOResponse>>(result);
            return response;
        }
        public async Task<ProveedorDTOResponse> GetByIdAsync(string id)
        {
            var result = await _proveedorDomainService.GetByIdAsync(id);
            var response = _mapper.Map<ProveedorDTOResponse>(result);
            return response;
        }
        public async Task<ProveedorDTOResponse> GetByDocument(ProveedorDTORequest obj)
        {
            var model = _mapper.Map<Proveedor>(obj);
            var result = await _proveedorDomainService.GetByDocument(model);
            var response = _mapper.Map<ProveedorDTOResponse>(result);
            return response;
        }
    }
}
 